using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {
	public Vector3 localGravity;
	private Rigidbody rb;
	public float x;
	public float y;
	public float z;
	public bool[] kabe;
	public float pos;
	public float rote;
	public int mae;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		//rb.useGravity = false;
		for (int i = 0; i < kabe.Length; i++) {
			kabe [i] = false;
		}
	}

	void Update ()
	{
		pos = Input.GetAxis ("Vertical");
		rote = Input.GetAxis ("Horizontal");

		x = transform.localEulerAngles.x;
		y = transform.localEulerAngles.y;
		z = transform.localEulerAngles.z;



		if (kabe[1]==true) {
			localGravity=new Vector3(0f,-9.5f,0f);
		}
		if (kabe[2]==true) {
			localGravity=new Vector3(0f,9.5f,0f);
		}

		if (kabe[3]==true) {
			localGravity=new Vector3(-9.5f,0f,0f);
		}

		if (kabe[4]==true) {
			localGravity=new Vector3(9.5f,0f,0f);
		}

		if (kabe[5]==true) {
			localGravity=new Vector3(0f,0f,9.5f);
		}

		if (kabe[6]==true) {
			localGravity=new Vector3(0f,0f,-9.5f);
		}
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
            Vector3 normal = col.gameObject.GetComponent<NormalVector>().normal;

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
