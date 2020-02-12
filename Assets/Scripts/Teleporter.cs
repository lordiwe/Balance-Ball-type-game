using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleport_exit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.gameObject.transform.position = teleport_exit.gameObject.transform.position;  
        }
    }
}
