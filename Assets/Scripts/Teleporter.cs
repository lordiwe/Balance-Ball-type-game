using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleport_exit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                other.gameObject.transform.position = teleport_exit.gameObject.transform.position;  
        }
    }
}
