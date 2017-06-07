using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {
	status ST;//ステータス
	public Vector3 localGravity;
	private Rigidbody rb;
	Vector3 normal;
	//public bool Color;

	void Start () {
		ST = GetComponent<status> ();
		rb = this.GetComponent<Rigidbody>();
		rb.useGravity = false;
		if (Random.value<0.5f) {
			ST.color = "red";
			this.transform.position = new Vector3 (0,-45,0);

			normal=new Vector3(0,1,0);
		} else {
			ST.color="blue";
			this.transform.position = new Vector3 (0,45,0);

			normal=new Vector3(0,-1,0);
		}
		localGravity = new Vector3(normal.x * -9.8f*2, normal.y * -9.8f*2, normal.z * -9.8f*2);
	}

	void Update ()
	{

		if (ST.STET == "del") {
			if (ST.color == "red") {
				this.transform.position = new Vector3 (0, -45, 0);
				normal = new Vector3 (0, 1, 0);
			}
			if (ST.color == "blue") {
				this.transform.position = new Vector3 (0, 45, 0);
				normal=new Vector3(0,-1,0);
			}
			localGravity = new Vector3(normal.x * -9.8f*2, normal.y * -9.8f*2, normal.z * -9.8f*2);
			ST.HP = ST.MAXHP;
			ST.STET = null;
		}
		Vector3 viewVec = Vector3.Cross(transform.right, normal);

		transform.rotation = Quaternion.LookRotation(viewVec, normal);
	} 
	
	void FixedUpdate () {
		setLocalGravity ();
	}

	void setLocalGravity(){
		rb.AddForce (localGravity, ForceMode.Acceleration);
	}

    //オブジェクトが衝突したとき
    void OnCollisionEnter(Collision col)
    {
        rb.useGravity = false;

        if (col.gameObject.CompareTag("Floor"))
        {
            normal = col.gameObject.GetComponent<NormalVector>().normal;
            localGravity = new Vector3(normal.x * -9.8f*2, normal.y * -9.8f*2, normal.z * -9.8f*2);

            // 外積 2つのベクトルが成す平面の法線方向を求める
            // 法線 面に垂直な線
            Vector3 viewVec = Vector3.Cross(transform.right, normal);

            transform.rotation = Quaternion.LookRotation(viewVec, normal);


            /*
            // ぶつかった先のフロアの法線のマイナス方向と、現在の正面方向の成す角度を求める
            float theta = Vector3.Angle(viewVec, transform.forward);
            Debug.Log(theta);

            Quaternion rot =  Quaternion.LookRotation(viewVec, normal);
            transform.rotation = Quaternion.AngleAxis(theta, rot * Vector3.up);
            */
        }
    }
        
}
