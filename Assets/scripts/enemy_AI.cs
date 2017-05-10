using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_AI : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnTriggerStay(Collision other) {
		if (other.gameObject.CompareTag ("Player")) {
			player = other.gameObject;
		}
	}
}
