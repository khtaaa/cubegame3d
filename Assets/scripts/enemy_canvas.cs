using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_canvas : MonoBehaviour {
	public GameObject rotatecamera;
	// Use this for initialization
	void Start () {
		rotatecamera = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = rotatecamera.transform.rotation;
	}
}
