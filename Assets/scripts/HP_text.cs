using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_text : MonoBehaviour {
	status ST;
	// Use this for initialization
	void Start () {
		ST =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject.GetComponent<status> ();
		GetComponent<Text> ().text = ST.HP+"/"+ST.MAXHP;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = ST.HP+"/"+ST.MAXHP;
	}
}
