using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spown : MonoBehaviour {
	public GameObject enemy;
	public bool ok;
	int height=5;
	Vector3 nor;

	// Use this for initialization
	void Start () {
		nor = GetComponent<NormalVector> ().normal;
		GameObject INSenemy = Instantiate (enemy, 
			new Vector3 (transform.position.x + nor.x * height,
				transform.position.y + nor.y * height,
				transform.position.z + nor.z * height), 
			Quaternion.identity) as GameObject;
		INSenemy.GetComponent<enemy> ().normal = nor;
		INSenemy.GetComponent<enemy> ().floor = this.gameObject;
		ok = false;
	}
	
	// Update is called once per frame
	void Update () {
		nor = GetComponent<NormalVector> ().normal;
		if (ok == true) {
			nor = GetComponent<NormalVector> ().normal;
			GameObject INSenemy = Instantiate (enemy, 
				new Vector3 (transform.position.x + nor.x * height,
					transform.position.y + nor.y * height,
					transform.position.z + nor.z * height), 
				Quaternion.identity) as GameObject;
			INSenemy.GetComponent<enemy> ().normal = nor;
			INSenemy.GetComponent<enemy> ().floor = this.gameObject;
			ok = false;
		}
	}
}
