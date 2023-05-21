using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_control : MonoBehaviour
{
    [SerializeField] private Transform trainTransform;

    private Vector3 offset;

    [SerializeField] private float lerpTime;

   
    void Start()
    {
        offset = transform.position - trainTransform.position;
    }

     void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, trainTransform.position + offset, lerpTime * Time.deltaTime);
        transform.position = newPos;
    }
}
