using UnityEngine;
using System.Collections;

public class binBehavior : MonoBehaviour {

	public GameObject pickups;
	public GameObject correctPickUp;
//	public bool occupied { get; set; }
	public bool holdingCorrectPickUp { get; set; }

	// Use this for initialization
	void Start () {
//		occupied = false;
		holdingCorrectPickUp = false;
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

	public void checkCorrectPickUp(GameObject pickup){
		//invariant is that occupied == false
//		occupied = true;
		if (string.Compare (pickup.name, correctPickUp.name) == 0) {
			Debug.Log ("this is the correct pick up");
			holdingCorrectPickUp = true;
		} else {
			holdingCorrectPickUp = false;
		}
	}
}
