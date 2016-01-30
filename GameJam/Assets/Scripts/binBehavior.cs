using UnityEngine;
using System.Collections;
using UnityEditor;

public class binBehavior : MonoBehaviour {

	public GameObject pickups;
	public string[] attrs;
	public bool activated { get; set; }
    SpriteRenderer myRend;

	// Use this for initialization
	void Awake () {
		activated = false;
        myRend = gameObject.GetComponent<SpriteRenderer>();
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
        if (!transform.gameObject.name.Contains("start"))
            myRend.color = new Color(1.0f, 0.0f, 0.0f);
        return false;
	}

    public void checkActivation(string[] pickupAttrs) {
        //invariant is that occupied == false
        foreach (string attr in attrs) {
            if (ArrayUtility.IndexOf(pickupAttrs, attr) < 0) {
                myRend.color = new Color(1.0f, 0.0f, 0.0f);
                activated = false;
                Debug.Log("this pickup does not turn me on");
                return;
            }
        }
        if (attrs.Length > 0) {
            myRend.color = new Color(0.0f, 1.0f, 0.0f);
            Debug.Log("this pickup turns me on");
            activated = true;
        }
	}
}
