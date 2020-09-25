using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{    
    void Start()
    {
       
    }
    void Update()
    {
        Vector3 vec = new Vector3
        (Input.GetAxis("Horizontal")*Time.deltaTime
        ,Input.GetAxis("Vertical")*Time.deltaTime
        ,0); //백터값
        transform.Translate(vec);
    }


}
