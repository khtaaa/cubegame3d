using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spown : MonoBehaviour {
	public GameObject enemy;
	int height=5;
	Vector3 nor;
	Vector3 inst;
	float insx;
	float insy;
	float insz;
	public int maxenemy=10;
	public int nowenemy;

	// Use this for initialization
	void Start () {
		ins ();
	}
	

	void Update () {
		if (nowenemy!=maxenemy) {
			ins ();
		}

		}

	public void ins()
	{
		nor = GetComponent<NormalVector> ().normal;
		if (nor.x == 0) {
			inst.x = Random.Range (-10.0f, 10.0f);
		}
		if (nor.x != 0) {
			inst.x = nor.x;
		}

		if (nor.y == 0) {
			inst.y = Random.Range (-10.0f, 10.0f);
		}
		if (nor.y != 0) {
			inst.y = nor.y;
		}

		if (nor.z == 0) {
			inst.z = Random.Range (-10.0f, 10.0f);
		}
		if (nor.z != 0) {
			inst.z = nor.z;
		}

		GameObject INSenemy = Instantiate (enemy, 
			new Vector3 (transform.position.x + inst.x * height,
				transform.position.y + inst.y * height,
				transform.position.z + inst.z * height), 
			Quaternion.identity) as GameObject;
		INSenemy.GetComponent<enemy> ().normal = nor;
		INSenemy.GetComponent<enemy> ().floor = this.gameObject;
		nowenemy++;
	}
}
