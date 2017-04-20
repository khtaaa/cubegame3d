using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {
	public Vector3 localGravity;
	private Rigidbody rb;

	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}

	void Update ()
	{
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
            localGravity = new Vector3(normal.x * -9.5f, normal.y * -9.5f, normal.z * -9.5f);

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
