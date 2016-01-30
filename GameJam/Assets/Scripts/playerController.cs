using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	private bool holding;
	private Vector3 mousePos;
	private LayerMask pickups;

	public GameObject grabber;
	private GameObject pickup;

	// Use this for initialization
	void Start () {
		holding = false;
		mousePos = Vector3.zero;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		pickups = 1 << LayerMask.NameToLayer ("pickup");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 camMousPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePos = new Vector3 (camMousPos.x, camMousPos.y, -camMousPos.z);
		setToMousePos (grabber);
		Debug.DrawRay (transform.position, mousePos, Color.yellow);
//		Debug.Log (mousePos.x + " " + mousePos.y);

		checkForGrabbing ();
	}

	void checkForGrabbing(){
		if (Input.GetMouseButtonDown(0) && !holding) {
			RaycastHit2D hit;
			if (hit = (Physics2D.Raycast (transform.position, mousePos, Mathf.Infinity, pickups))) {
				pickup = hit.transform.gameObject;
				setToMousePos (pickup);
				holding = true;
				Debug.Log ("pickup");
			}
		}
		if (Input.GetMouseButton (0)) {
			if (holding) {
				setToMousePos (pickup);
			}
		} else {
			release ();
		}
	}

	void release(){
		if (holding) {
			//call pickup.release function that checks for any bins nearby and snap to nearest one, otherwise
			//go back to original position
			pickUpBehavior pickUpScript = pickup.GetComponent<pickUpBehavior>();
			pickUpScript.released ();
			holding = false;
		}
	}

	void setToMousePos(GameObject obj){
		obj.transform.position = new Vector3 (mousePos.x, mousePos.y, obj.transform.position.z);
	}
}
