using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaffold : MonoBehaviour {
	int time =0;
	public bool ok;

	// Use this for initialization
	void Start () {
		time = 0;
		ok = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(ok==false)
		time++;

		if (time == 180) {
			time = 0;
			Destroy (gameObject);
		}

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			ok = true;
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.CompareTag ("Player")) {
			Destroy(gameObject);
		}
	}
}
