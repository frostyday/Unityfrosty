using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody >();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       /*() if(Input.GetButtonDown("Jump")){
            rigid.AddForce(Vector3.up * 25, ForceMode.Impulse);
            Debug.Log(rigid.velocity);
        }

        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal")
        ,0, Input.GetAxisRaw("Vertical"));
       
        rigid.AddForce(vec, ForceMode.Impulse);
       */
       rigid.AddTorque(Vector3.up);
    }
}
