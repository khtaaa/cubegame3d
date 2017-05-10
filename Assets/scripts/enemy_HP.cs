using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_HP : MonoBehaviour {
	status enemystatus;
	public float HP=100;
	public float MAXHP=100;
	Slider _slider;
	void Start () {
		enemystatus =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject.GetComponent<status> ();
		_slider = this.gameObject.GetComponent<Slider> ();
		HP = enemystatus.HP;
		MAXHP = enemystatus.MAXHP;
		_slider.maxValue = MAXHP;
	}
	void Update () {
		enemystatus =gameObject.transform.parent.gameObject.gameObject.transform.parent.gameObject.GetComponent<status> ();
		HP = enemystatus.HP;
		MAXHP = enemystatus.MAXHP;
		_slider.value = HP/MAXHP*100;
	}
}
