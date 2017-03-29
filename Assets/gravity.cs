using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {
	public Vector3 localGravity;
	private Rigidbody rb;
	public float x;
	public float y;
	public float z;
	public bool[] kabe;
	public float pos;
	public float rote;
	public int mae;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		//rb.useGravity = false;
		for (int i = 0; i < kabe.Length; i++) {
			kabe [i] = false;
		}
	}

	void Update ()
	{
		pos = Input.GetAxis ("Vertical");
		rote = Input.GetAxis ("Horizontal");

		x = transform.localEulerAngles.x;
		y = transform.localEulerAngles.y;
		z = transform.localEulerAngles.z;



		if (kabe[1]==true) {
			localGravity=new Vector3(0f,-9.5f,0f);
		}
		if (kabe[2]==true) {
			localGravity=new Vector3(0f,9.5f,0f);
		}

		if (kabe[3]==true) {
			localGravity=new Vector3(-9.5f,0f,0f);
		}

		if (kabe[4]==true) {
			localGravity=new Vector3(9.5f,0f,0f);
		}

		if (kabe[5]==true) {
			localGravity=new Vector3(0f,0f,9.5f);
		}

		if (kabe[6]==true) {
			localGravity=new Vector3(0f,0f,-9.5f);
		}
	} 
	
	void FixedUpdate () {
		setLocalGravity ();
	}

	void setLocalGravity(){
		rb.AddForce (localGravity, ForceMode.Acceleration);
	}

	//オブジェクトが衝突したとき
	void OnCollisionEnter(Collision col) {
		rb.useGravity = false;
		if (col.transform.gameObject.CompareTag ("1")) {
			mae = 1;
			transform.rotation = Quaternion.Euler ((float)Space.World, y, (float)Space.World);
			kabe [1] = true;
		}
		if (col.transform.gameObject.CompareTag ("2")) {
			mae = 2;
			transform.rotation=Quaternion.Euler(90,y,90);
			kabe [2] = true;
		}
		if (col.transform.gameObject.CompareTag ("3")) {
			mae = 3;
			transform.rotation=Quaternion.Euler(x,0,-90);
			kabe [3] = true;
		}
		if (col.transform.gameObject.CompareTag ("4")) {
			mae = 4;
			transform.rotation=Quaternion.Euler(x,0,90);
			kabe [4] = true;
		}
		if (col.transform.gameObject.CompareTag ("5")) {
			mae = 5;
			transform.rotation=Quaternion.Euler(x,90,-90);
			kabe [5] = true;
		}
		if (col.transform.gameObject.CompareTag ("6")) {
			mae = 6;
			transform.rotation=Quaternion.Euler(x,-90,-90);
			kabe [6] = true;
		}
	}
	void OnCollisionExit(Collision col) {
		if (col.transform.gameObject.CompareTag ("1")) {
			mae = 1;
			kabe [1] = false;
		}
		if (col.transform.gameObject.CompareTag ("2")) {
			mae = 2;
			kabe [2] = false;
		}
		if (col.transform.gameObject.CompareTag ("3")) {
			mae = 3;
			kabe [3] = false;
		}
		if (col.transform.gameObject.CompareTag ("4")) {
			mae = 4;
			kabe [4] = false;
		}
		if (col.transform.gameObject.CompareTag ("5")) {
			mae = 5;
			kabe [5] = false;
		}
		if (col.transform.gameObject.CompareTag ("6")) {
			mae = 6;
			kabe [6] = false;
		}
	}
}
