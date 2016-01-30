using UnityEngine;
using System.Collections;

//comment

public class pickUpBehavior : MonoBehaviour {

	private Vector3 origPos;
	public GameObject bins; //empty gameobject containing all the bins
	private float binDist;
	private GameObject currBin;
	public string[] attrs;

	// Use this for initialization
	void Start () {
		origPos = transform.position;
		binDist = 2.5f;
		currBin = null;
	}

	public void released(){
		//loop through all the bins, find the closest bin, if closest <= binDist, 
		//translate pickup to that binPos and check if bin is correct bin, otherwise translate to origpos
		Debug.Log("I was released!");
		float mindist = Mathf.Infinity;
		float distance;
		Transform closestBin = transform;
		foreach (Transform bin in bins.transform) {
			binBehavior binScript = bin.gameObject.GetComponent<binBehavior> ();
			if (!binScript.isOccupied()) { 
				distance = Vector3.Distance (transform.position, bin.position);
				Debug.Log (distance);
				if (distance < mindist) {
					mindist = distance;
					closestBin = bin;
				}
			}
		}
		if (mindist < binDist) {
			Debug.Log ("snapped to bin!");
			transform.position = closestBin.transform.position;
			resetCurrBin ();
			closestBin.gameObject.GetComponent<binBehavior> ().checkActivation (attrs);
			currBin = closestBin.gameObject;
		} else {
			Debug.Log ("snapped to origPos, wasnt close enough to a vacant bin!");
			transform.position = origPos;
			resetCurrBin ();
		}
	}

	private void resetCurrBin(){
		if (currBin != null) {
			//it was last at this bin, so this bin is now free
			binBehavior currBinScript = currBin.GetComponent<binBehavior>();
			currBinScript.activated = false;
			Debug.Log ("this bin is no longer holding anything");
		}
		currBin = null;
	}

	//perhaps used for animations or jiggling or detecting if ghost nearby?
//	// Update is called once per frame 
//	void Update () {
//	
//	}
}
