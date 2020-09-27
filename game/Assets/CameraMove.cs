using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;
    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }

    
    void LateUpdate() //ui나 카메라 쓸때 사용 LateUpdate
    {
        transform.position = playerTransform.position + Offset;
    }
}
