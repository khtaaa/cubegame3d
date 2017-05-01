using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour {
	public GameObject rock;
	Vector3 nor;

	// Use this for initialization
	void Start () {
		nor = this.GetComponent<player> ().normal;
	}
	
	// Update is called once per frame
	void Update () {
		nor = this.GetComponent<player> ().normal;

		if (Input.GetKeyDown (KeyCode.KeypadEnter)) {
			//Instantiate (rock, new Vector3 (transform.position.x, transform.position.y+10f, transform.position.z), Quaternion.identity);
			//オブジェクトを変数名bulletで生成
			GameObject INSrock = Instantiate(rock, new Vector3(transform.position.x+nor.x*10,transform.position.y+nor.y*10,transform.position.z+nor.z*10), Quaternion.identity) as GameObject;
			//名前を変更
			INSrock.name = "B";
			INSrock.GetComponent<rock> ().normal = this.GetComponent<player> ().normal;
		}
	}
}
