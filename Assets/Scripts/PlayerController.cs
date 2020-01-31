using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public Text lifesText;
    // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
    private Rigidbody rb;
    private int lifes;
    private GameObject playerObj;
    private GameObject respawn;

    protected Joystick joystick;

    public Transform cam;

    public AudioClip fallSound;
    public bool playSoundCheck;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable

        playerObj = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.FindGameObjectWithTag("Respawn");

        
        rb = GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();

        lifes = 3;

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
                playerObj.transform.position = respawn.transform.position;
                SetLifesText();
                playSoundCheck = false;
            }
            else
            {
                SceneManager.LoadScene(4);
            }
        }
    }
    // Each physics step..
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

    // When this game object intersects a collider with 'is trigger' checked, 
    // store a reference to that collider in a variable named 'other'..
    void OnTriggerEnter(Collider other)
    {
        
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetCountText()
    {
        
    }
    void SetLifesText()
    {
        //lifesText.text = "Lifes: " + lifes.ToString();
    }
}