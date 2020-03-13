using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MaterialChanger : MonoBehaviour
{
    public int texture_id;

    public bool changed = false;
    //public Renderer rend;
    MaterialChanger Changer;

    private void Start()
    {
        Changer = FindObjectOfType<MaterialChanger>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Renderer>().material != other.GetComponent<PlayerController>().materials[texture_id])
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

                                other.GetComponent<Rigidbody>().mass = 2;
                                other.GetComponent<PlayerController>().speed = 10;
                                break;
                            }
                        case 1:
                            {
                                other.GetComponent<Rigidbody>().mass = 10;
                                other.GetComponent<PlayerController>().speed = 30;
                                break;
                            }
                        case 2:
                            {
                                other.GetComponent<Rigidbody>().mass = 1;
                                other.GetComponent<PlayerController>().speed = 10;
                                break;
                            }
                        case 3:
                            {
                                other.GetComponent<Rigidbody>().mass = 1;
                                other.GetComponent<PlayerController>().speed = 10;
                                break;
                            }
                    }
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }



                
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
