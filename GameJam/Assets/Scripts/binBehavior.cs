using UnityEngine;
using System.Collections;
using UnityEditor;

public class binBehavior : MonoBehaviour {

	public GameObject pickups;
	public string[] attrs;
	public bool activated { get; set; }

	// Use this for initialization
	void Start () {
		activated = false;
	}

	public bool isOccupied(){
		//loop through all the pickups every frame and check if any of their positions is same as this, and if it is,
		//occupied true, and if none, then occupied false?
		foreach (Transform pickup in pickups.transform){
			if (pickup.position == transform.position) {
				Debug.Log ("this bin is occupado");
				return true;
			}
		}
		return false;
	}

	public void checkActivation(string[] pickupAttrs){
		//invariant is that occupied == false
		foreach (string attr in attrs) {
			if (ArrayUtility.IndexOf(pickupAttrs, attr) < 0){
				activated = false;
				Debug.Log ("this pickup does not turn me on");
				return;
			}
		}
		Debug.Log ("this pickup turns me on");
		activated = true;
	}
}
