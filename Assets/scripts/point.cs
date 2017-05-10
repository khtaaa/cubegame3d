using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour {
	public Material red;
	public Material blue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			if (col.gameObject.GetComponent<gravity> ().Color == true) {
				this.GetComponent<Renderer> ().material = red;
			}

			if (col.gameObject.GetComponent<gravity> ().Color == false) {
				this.GetComponent<Renderer> ().material = blue;
			}
		}
	}
}
