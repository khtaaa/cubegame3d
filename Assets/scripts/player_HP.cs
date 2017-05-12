using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_HP : MonoBehaviour {
	status ST;
	public float HP=100;
	public float MAXHP=100;
	Slider _slider;
	void Start () {
		ST =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject.GetComponent<status> ();
		_slider = this.gameObject.GetComponent<Slider> ();
		HP =ST.HP;
		MAXHP = ST.MAXHP;
		_slider.maxValue = MAXHP;
	}
	void Update () {
		ST =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject.GetComponent<status> ();
		HP = ST.HP;
		MAXHP = ST.MAXHP;
		_slider.value = HP/MAXHP*100;
		if (HP <= 0) {
			//Application.LoadLevel("title");
			ST.STET="del";
		}
	}
}
