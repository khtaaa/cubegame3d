using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	status ST;
	public float pos;//Vertical
	public float rote;//Horizontal
	public bool floor;//床に触れているか
	public Vector3 normal;//上を判定
	public Vector3 localGravity;//現在の重力の方向
	private Rigidbody rb;//Rigidbody

	void Start () {
		ST = GetComponent<status> ();//ステータス獲得
		rb = this.GetComponent<Rigidbody>();//Rigidbody獲得
		rb.useGravity = false;//重力オフ
		ST.HP = ST.MAXHP;//HPを全回復
		ST.STET = "LIVE";//状態をLIVEに

		//チームの色を決定
		if (Random.value<0.5f) {
			ST.color = "red";//自分の色を赤にする
		} else {
			ST.color="blue";//自分の色を青にする
		}

		setstart();//初期位置に移動
	}

	void Update () {
		//死んだ時
		if (ST.STET == "del") {
			setstart();//初期位置に移動
			ST.HP = ST.MAXHP;//HPを全回復
			ST.STET = "LIVE";//状態をLIVEに
		}
		
		pos = Input.GetAxis ("Vertical");
		rote = Input.GetAxis ("Horizontal");

		transform.Translate (0f, 0f, pos*ST.speed);//移動
		transform.Rotate (0f, rote, 0f);//回転

		//ジャンプ
		if (Input.GetKeyDown (KeyCode.Space) && floor==true) {
			this.GetComponent<Rigidbody> ().velocity = normal*9.8f*1.5f;
		}

		// 外積 2つのベクトルが成す平面の法線方向を求める
		// 法線 面に垂直な線
		Vector3 viewVec = Vector3.Cross(transform.right, normal);
		transform.rotation = Quaternion.LookRotation(viewVec, normal);
	}

	void FixedUpdate () {
		//重力を人工的に作成
		rb.AddForce (localGravity, ForceMode.Acceleration);
	}

	//初期位置
	void setstart()
	{
		//赤チームなら
		if (ST.color == "red") {
			this.transform.position = new Vector3 (0,-45,0);//赤のスポーン位置に移動
			normal=new Vector3(0,1,0);//赤の初期の上を決定
		}
		//青チームなら
		if (ST.color == "blue") {
			this.transform.position = new Vector3 (0,45,0);//青のスポーン位置に移動
			normal=new Vector3(0,-1,0);//青の初期の上を決定
		}
		localGravity = new Vector3(normal.x * -9.8f*2, normal.y * -9.8f*2, normal.z * -9.8f*2);//上を判断して重力を獲得
	}


	//オブジェクトが触れた時
	void OnCollisionEnter(Collision col)
	{
		//enemy以外に触れたら
		if (!col.gameObject.CompareTag("enemy")) {
			//floorに触れたら
			if (col.gameObject.CompareTag ("Floor")) {
				//床に対しての上を獲得
				normal = col.gameObject.GetComponent<NormalVector> ().normal;
				localGravity = new Vector3(normal.x * -9.8f*2, normal.y * -9.8f*2, normal.z * -9.8f*2);//上を判断して重力を獲得
			}
			floor = true;//床に触れている
		}
	}

	//オブジェクトが触れ続けている間
	void OnCollisionStay(Collision col) {
		//enemy以外に触れている間
		if (!col.gameObject.CompareTag ("enemy")) {
			//floorに触れている間
			if (col.gameObject.CompareTag ("Floor")) {
				//床に対しての上を獲得
				normal = col.gameObject.GetComponent<NormalVector> ().normal;
			}
			floor = true;//床に触れている
		}
	}

	//オブジェクトから離れた時
	void OnCollisionExit(Collision col) {
		//enemy以外なら
		if (!col.gameObject.CompareTag ("enemy")) {
			floor = false;//床に触れていない
		}
	}

}
