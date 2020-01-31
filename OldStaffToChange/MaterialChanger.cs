using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material[] textures;
    public int CurrentTexture;
    public bool changed = false;
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        //rend.enabled = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TextureChanger"))
        {
            if (!changed)
            {
                changed = true;
                CurrentTexture++;
                CurrentTexture %= textures.Length;
                GetComponent<Renderer>().material = textures[CurrentTexture];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TextureChanger"))
        {
            changed = false;
        }
    }

}
