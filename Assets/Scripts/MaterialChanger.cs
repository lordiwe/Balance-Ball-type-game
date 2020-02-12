using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MaterialChanger : MonoBehaviour
{


    public float timer;

    private float tmpDrag;

    public int texture_id;

    public bool changed = false;
    //public Renderer rend;
    MaterialChanger Changer;

    private void Start()
    {
        timer = 2;
        Changer = FindObjectOfType<MaterialChanger>();
    }

    public void OnTriggerEnter(Collider other)
    {
        tmpDrag = other.GetComponent<Rigidbody>().drag;
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Vector3 position = new Vector3(Changer.gameObject.transform.position.x, 
                other.gameObject.transform.position.y, 
                Changer.gameObject.transform.position.z);

            if (!changed)
            {
                other.gameObject.transform.position = position;
                MaterialChange(other);

                switch (texture_id)
                {
                    case 0:
                        {

                            break;
                        }
                    case 1:
                        {

                            break;
                        }
                    case 2:
                        {

                            break;
                        }
                }
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;





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

    public void MaterialChange(Collider other)
    {
        changed = true;
        other.GetComponent<Renderer>().material = other.GetComponent<PlayerController>().materials[texture_id];

    }

}
