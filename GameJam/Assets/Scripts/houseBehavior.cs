using UnityEngine;
using System.Collections;

public class houseBehavior : MonoBehaviour {

	public GameObject[] housebins;
	public bool activated { get; set; }
	public bool available { get; set; }
	private binBehavior[] binScripts;
	public GameObject nextHouse;

	// Use this for initialization
	void Start () {
		activated = false;
		available = false;
		if (transform.gameObject.name.Contains("1"))
			available = true;
		binScripts = new binBehavior[housebins.Length];
		for (int i = 0; i < housebins.Length; i++) {
			binScripts [i] = housebins [i].GetComponent<binBehavior> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!activated && available) {
			int badCount = 0;
			foreach (binBehavior binScript in binScripts) {
				if (!binScript.activated) {
					badCount++;
				}
			}
			if (badCount == 0) {
				activated = true;
				makeNextHouseAvailable ();
				Debug.Log ("house has been activated! make next house available");
			}
		}
	}

	void makeNextHouseAvailable(){
		if (nextHouse != null) {
			nextHouse.GetComponent<houseBehavior> ().available = true;
			foreach (Transform child in nextHouse.transform) {
				if (child.name.Contains ("wall")) {
					child.gameObject.SetActive (false);
					break;
				}
			}
		} else {
			Debug.Log ("this is the last house! you win!");
		}
	}
				
}
