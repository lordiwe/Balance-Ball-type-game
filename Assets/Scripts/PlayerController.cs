using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Text lifesText;

    private Rigidbody rb;

    private int lifes;

    private GameObject playerObj;

    public GameObject currentCheckpoint;

    protected Joystick joystick;

    public Transform cam;

    public AudioClip fallSound;
    public bool playSoundCheck;

    public Material[] materials;


    // At the start of the game..
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        currentCheckpoint = GameObject.FindGameObjectWithTag("Respawn");
        

        
        rb = GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();

        lifes = 1;

        SetLifesText();
        

        playSoundCheck = false;

        

    }
    public void Update()
    {
        if (playerObj.transform.position.y < -2 && playSoundCheck == false)
        {
            //FindObjectOfType<AudioSource>().PlayOneShot(fallSound);
            playSoundCheck = true;
        }
        if (playerObj.transform.position.y < -15)
        {

            if (lifes > 0)
            {
                lifes--;
                StopMovement();
                playerObj.transform.position = currentCheckpoint.transform.position;
                SetLifesText();
                playSoundCheck = false;
            }
            else
            {
                StopMovement();
                playerObj.transform.position = currentCheckpoint.transform.position;
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(speed * movement);

        Vector3 movement = new Vector3(-joystick.Horizontal,
                    0, -joystick.Vertical);
        rb.AddForce(movement * speed);

    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CheckPoint"))
        {
            currentCheckpoint = other.gameObject;

            Debug.LogWarning("Checkpoint reached!");

            other.gameObject.SetActive(false);
        }

        if(other.CompareTag("Finish"))
        {
            Debug.LogWarning("Finish reached!");

        }
    }

    
    void SetLifesText()
    {
        //lifesText.text = "Lifes: " + lifes.ToString();
    }

    void StopMovement()
    {
        playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}