using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesActivate : MonoBehaviour
{
    public ParticleSystem particle1, particle2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            particle1.Play();
            particle2.Play();
        }
    }
}
