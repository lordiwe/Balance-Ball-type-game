using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //public float x;
    //public float y;
    //public float z;
    float speed = 50f;
    void Update()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }
}
