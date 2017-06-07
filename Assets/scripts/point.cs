using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour {
	public Material red;//赤のマテリアル
	public Material blue;//青のマテリアル
	public string coler;//自分の色の情報
	public string Pcoler;//プレイヤーの色
	public float time;//カウント
	public float maxtime;//色変更までの時間
	public bool stay;//プレイヤーが触れているか
	// Use this for initialization
	void Start () {
		coler="white";//白色に変化
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
						coler="red";//自分の色の情報を赤色に
					}

					if (coler == "blue") {
						manager.redpoint++;
						manager.bluepoint--;
						coler="red";//自分の色の情報を赤色に
					}
					this.GetComponent<Renderer> ().material = red;//赤色に変化
				}

				if (Pcoler == "blue") {
					if (coler=="white") {
						manager.bluepoint++;
						coler="blue";//自分の色の情報を青色に
					}

					if (coler == "red") {
						manager.redpoint--;
						manager.bluepoint++;
						coler="blue";//自分の色の情報を青色に
					}
					this.GetComponent<Renderer> ().material = blue;//青色に変化

				}
			}
		}
	}
	//オブジェクトが触れた時
	void OnCollisionEnter(Collision col)
	{
		//プレイヤーが触れた時
		if (col.gameObject.CompareTag ("Player")) {
			stay = true;//触れている
			Pcoler = col.gameObject.GetComponent<status> ().color;//プレイヤーの色を獲得
		}
	}
	//オブジェクトが離れた時
	void OnCollisionExit(Collision col)
	{
		//プレイヤーが離れた時
		if (col.gameObject.CompareTag ("Player")) {
			stay = false;//触れていない
			time = 0;
		}
	}
}
