using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {
	public static int redpoint;
	public static int bluepoint;
	public static int player_SP=0;
	public float SPtime;
	public float SPmaxtime;
	// Use this for initialization
	void Start () {
		SPtime = 0;
		redpoint = 0;
		bluepoint = 0;
		player_SP = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (redpoint >= bluepoint + 4) {
			Application.LoadLevel("title");
		}

		if (bluepoint >= redpoint + 4) {
			Application.LoadLevel("title");
		}
	}
}
