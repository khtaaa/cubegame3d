using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour {
	public GameObject rock;
	Vector3 nor;
	public GameObject scaffold;

	// Use this for initialization
	void Start () {
		nor = this.GetComponent<player> ().normal;
	}
	
	// Update is called once per frame
	void Update () {
		nor = this.GetComponent<player> ().normal;

		if (Input.GetKeyDown (KeyCode.KeypadEnter)) {
			
			GameObject INSrock = Instantiate (rock, 
				                     new Vector3 (transform.position.x + nor.x * 10,
					                     transform.position.y + nor.y * 10,
					                     transform.position.z + nor.z * 10), 
				                     Quaternion.identity) as GameObject;
			INSrock.GetComponent<rock> ().normal = this.GetComponent<player> ().normal;
		}

		if (GetComponent<player> ().floor == false) {
			if(Input.GetKeyDown (KeyCode.Keypad1)){
			Instantiate (scaffold, new Vector3 (transform.position.x + nor.x * -1.6f,
				transform.position.y + nor.y * -1.6f,
				transform.position.z + nor.z * -1.6f), Quaternion.identity);
			}
		}
	}
}
