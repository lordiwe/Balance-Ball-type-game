using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float smoothSpeed = 0.125f;

    public Vector3 offset;


    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(player.transform);
        //transform.position = transform.position * distance * Time.deltaTime;
    }
}