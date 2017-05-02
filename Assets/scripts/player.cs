using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float pos;
	public float rote;
	public bool floor;
	public Vector3 normal;
	public int speed=20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pos = Input.GetAxis ("Vertical");
		rote = Input.GetAxis ("Horizontal");

		transform.Translate (0f, 0f, pos*speed*0.01f);
		transform.Rotate (0f, rote, 0f);

		if (Input.GetKeyDown (KeyCode.Space) && floor==true) {
			this.GetComponent<Rigidbody> ().velocity = normal*9.8f;//new Vector3 (this.GetComponent<Rigidbody> ().velocity.x, 10, 0);
			floor = false;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (!col.gameObject.CompareTag("enemy")) {
			if (col.gameObject.CompareTag ("Floor")) {
				normal = col.gameObject.GetComponent<NormalVector> ().normal;
			}
			floor = true;
		}

		if (col.gameObject.CompareTag ("rock")) {
			speed = 8;
			
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.CompareTag ("rock")) {
			speed = 20;

		}
	}

}
