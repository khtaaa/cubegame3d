using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour {
	public Material red;
	public Material blue;
	public string coler;
	public string Pcoler;
	public float time;
	public float maxtime;
	public bool stay;
	// Use this for initialization
	void Start () {
		coler="white";
		time = 0;
		stay = false;
		Pcoler = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (stay == true) {
			time += Time.deltaTime;
			if (time > maxtime) {
				time = 0;
				if (Pcoler == "red") {
					if (coler=="white") {
						manager.redpoint++;
						coler="red";
					}

					if (coler == "blue") {
						manager.redpoint++;
						manager.bluepoint--;
						coler="red";
					}
					this.GetComponent<Renderer> ().material = red;
				}

				if (Pcoler == "blue") {
					if (coler=="white") {
						manager.bluepoint++;
						coler="blue";
					}

					if (coler == "red") {
						manager.redpoint--;
						manager.bluepoint++;
						coler="blue";
					}
					this.GetComponent<Renderer> ().material = blue;

				}
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			stay = true;
			Pcoler = col.gameObject.GetComponent<status> ().color;
		}
	}

	void OnCollisionExit(Collision col)
	{
		stay = false;
		time = 0;
	}
}
