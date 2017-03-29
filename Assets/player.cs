using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float pos;
	public float rote;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		pos = Input.GetAxis ("Vertical");
		rote = Input.GetAxis ("Horizontal");

		transform.Translate (0f, 0f, pos/10);
		transform.Rotate (0f, rote, 0f);

		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.Translate (0f, 1f, 0f);
		}
	}

}
