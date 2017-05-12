using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	status ST;
	public float pos;
	public float rote;
	public bool floor;
	public Vector3 normal;
	// Use this for initialization
	void Start () {
		ST = GetComponent<status> ();
	}
	
	// Update is called once per frame
	void Update () {
		pos = Input.GetAxis ("Vertical");
		rote = Input.GetAxis ("Horizontal");

		transform.Translate (0f, 0f, pos*ST.speed*0.01f);
		transform.Rotate (0f, rote, 0f);

		if (Input.GetKeyDown (KeyCode.Space) && floor==true) {
			this.GetComponent<Rigidbody> ().velocity = normal*9.8f*1.5f;//new Vector3 (this.GetComponent<Rigidbody> ().velocity.x, 10, 0);
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
			ST.speed = 8;
			
		}
	}


	void OnCollisionStay(Collision col) {

		if (!col.gameObject.CompareTag ("enemy")) {
			if (col.gameObject.CompareTag ("Floor")) {
				normal = col.gameObject.GetComponent<NormalVector> ().normal;
			}
			floor = true;
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.CompareTag ("rock")) {
			ST.speed = 20;

		}

		if (!col.gameObject.CompareTag ("enemy")) {
			floor = false;
		}
	}

}
