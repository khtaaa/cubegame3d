using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public Vector3 localGravity;
	private Rigidbody rb;
	public Vector3 normal;
	public GameObject floor;
	status enemystatus;

	// Use this for initialization
	void Start () {
		enemystatus=this.gameObject.GetComponent<status> ();
		rb = this.GetComponent<Rigidbody>();
		rb.useGravity = false;
		localGravity = new Vector3(normal.x * -9.8f, normal.y * -9.8f, normal.z * -9.8f);
	}

	// Update is called once per frame
	void Update () {
		localGravity = new Vector3(normal.x * -9.8f, normal.y * -9.8f, normal.z * -9.8f);
		Vector3 viewVec = Vector3.Cross(transform.right, normal);

		transform.rotation = Quaternion.LookRotation(viewVec, normal);
	}

	void FixedUpdate () {
		setLocalGravity ();
	}

	void setLocalGravity(){
		rb.AddForce (localGravity, ForceMode.Acceleration);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			enemystatus.HP -= 5;
			if (enemystatus.HP <= 0) {
				floor.GetComponent<enemy_spown> ().nowenemy--;
				Destroy (gameObject);
			}

		}
	}
}
