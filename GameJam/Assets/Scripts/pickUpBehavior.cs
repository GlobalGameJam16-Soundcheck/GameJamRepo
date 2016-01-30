using UnityEngine;
using System.Collections;

public class pickUpBehavior : MonoBehaviour {

	private Vector3 origPos;
	public GameObject bins; //empty gameobject containing all the bins
	private float binDist;

	// Use this for initialization
	void Start () {
		origPos = transform.position;
		binDist = 2.5f;
	}

	public void released(){
		//loop through all the bins, find the closest bin, if closest <= binDist, 
		//translate pickup to that binPos and check if bin is correct bin, otherwise translate to origpos
		Debug.Log("I was released!");
		float mindist = Mathf.Infinity;
		float distance;
		Transform closestBin = transform;
		foreach (Transform bin in bins.transform) {
			distance = Vector3.Distance (transform.position, bin.position);
			Debug.Log (distance);
			if (distance < mindist) {
				mindist = distance;
				closestBin = bin;
			}
		}
		if (mindist < binDist) {
			Debug.Log ("snapped to bin!");
			transform.position = closestBin.position;
		} else {
			Debug.Log ("snapped to origPos!");
			transform.position = origPos;
		}
	}

	//perhaps used for animations or jiggling or detecting if ghost nearby?
//	// Update is called once per frame 
//	void Update () {
//	
//	}
}
