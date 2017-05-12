using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_AI : MonoBehaviour {
	public bool Discovery;
	public GameObject player;
	Vector3 dir;
	public bool floor;
	// Use this for initialization
	void Start () {
		Discovery = false;
		floor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Discovery == true&& player!=null) {
			//transform.rotation = player.transform.rotation;
			dir = player.transform.position - transform.position;
			dir = dir.normalized;
			GetComponent<Rigidbody> ().velocity = dir * 5;
			//transform.Translate (0f, 0f, -0.05f);
		} else {
			if (floor == true)
				GetComponent<Rigidbody> ().velocity = dir * 0;
				//transform.Translate (0f, 0f, 0f);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Floor")) {
			floor = true;
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.CompareTag ("Floor")) {
			floor = false;
		}
	}

}
