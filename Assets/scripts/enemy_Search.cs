using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Search : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("発見");
			gameObject.transform.parent.gameObject.GetComponent<enemy_AI>().player = other.gameObject;
			gameObject.transform.parent.gameObject.GetComponent<enemy_AI>().Discovery = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("見失った");
			gameObject.transform.parent.gameObject.GetComponent<enemy_AI>().player = null;
			gameObject.transform.parent.gameObject.GetComponent<enemy_AI>().Discovery = false;
		}
	}
}
