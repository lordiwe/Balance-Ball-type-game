using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material texture;
    //public int CurrentTexture;
    public bool changed = false;
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        //rend.enabled = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!changed)
            {
                changed = true;
                other.GetComponent<Renderer>().material = texture;
                //CurrentTexture++;
                //CurrentTexture %= textures.Length;
                //GetComponent<Renderer>().material = textures[CurrentTexture];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            changed = false;
        }
    }

}
