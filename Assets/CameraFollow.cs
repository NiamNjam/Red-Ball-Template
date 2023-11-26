using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothness;
    // Update is called once per frame
    void Update()
    {
        var pos = target.position;
        pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, pos, smoothness);// kamera bisk veluoja
    }
}
