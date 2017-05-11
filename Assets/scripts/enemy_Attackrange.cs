using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Attackrange : MonoBehaviour {
	public float maxtime;
	public float time;
	public bool attack;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (attack == true) {
			time -= Time.deltaTime;
			if (time < 0) {
				time = maxtime;
				gameObject.transform.parent.gameObject.GetComponent<enemy_AI> ().player.GetComponent<status> ().HP -= 10;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("範囲内");
			gameObject.transform.parent.gameObject.GetComponent<enemy_AI>().Discovery = false;
			attack = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("範囲外");
			gameObject.transform.parent.gameObject.GetComponent<enemy_AI>().Discovery = true;
			attack = false;
		}
	}
}
