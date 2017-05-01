using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour {
	public Vector3 localGravity;
	private Rigidbody rb;
	public Vector3 normal;


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		Destroy(gameObject,5f);
	}
	
	// Update is called once per frame
	void Update () {
		localGravity = new Vector3(normal.x * -9.8f, normal.y * -9.8f, normal.z * -9.8f);
	}

	void FixedUpdate () {
		setLocalGravity ();
	}

	void setLocalGravity(){
		rb.AddForce (localGravity, ForceMode.Acceleration);
	}
		
}
