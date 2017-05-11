using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_HP : MonoBehaviour {
	status playerstatus;
	public float HP=100;
	public float MAXHP=100;
	Slider _slider;
	void Start () {
		playerstatus =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject.GetComponent<status> ();
		_slider = this.gameObject.GetComponent<Slider> ();
		HP =playerstatus.HP;
		MAXHP = playerstatus.MAXHP;
		_slider.maxValue = MAXHP;
	}
	void Update () {
		playerstatus =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject.GetComponent<status> ();
		HP = playerstatus.HP;
		MAXHP = playerstatus.MAXHP;
		_slider.value = HP/MAXHP*100;
		if (HP <= 0) {
			Application.LoadLevel("title");
		}
	}
}
