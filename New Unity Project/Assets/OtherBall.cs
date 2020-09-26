using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer mesh;
    Material mat;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();  
        mat = mesh.material;  
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "MyBall") 
            mat.color = new Color(0,0,0);
    }

     private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "MyBall") 
            mat.color = new Color(2,2,2);
    }
}
