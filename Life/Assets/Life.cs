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
        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0); //백터값
        transform.Translate(vec);
    }


}
