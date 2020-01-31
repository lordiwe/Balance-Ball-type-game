using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                other.gameObject.transform.position = target.gameObject.transform.position;            
        }
    }
}
