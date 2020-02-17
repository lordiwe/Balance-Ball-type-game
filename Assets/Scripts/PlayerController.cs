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

    public Text timerText;

    private float time;

    private Rigidbody rb;

    private Collider coll;

    private int lifes;

    private GameObject playerObj;

    private GameObject currentCheckpoint;

    protected Joystick joystick;
    protected JumpButton jumpButton;

    protected bool jump;

    public Transform cam;

    public AudioClip fallSound;
    public bool playSoundCheck;

    public Material[] materials;


    // At the start of the game..
    void Start()
    {
        Time.timeScale = 1f;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        currentCheckpoint = GameObject.FindGameObjectWithTag("Respawn");

        time = 0;
        
        rb = GetComponent<Rigidbody>();

        coll = GetComponent<Collider>();

        joystick = FindObjectOfType<Joystick>();
        jumpButton = FindObjectOfType<JumpButton>();

        lifes = 3;

        SetLifesText();
        

        playSoundCheck = false;
        

    }
    public void Update()
    {
        time += Time.deltaTime;
        TimerUpdate();

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
            else if (lifes <= 0)
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

        if(!jump && jumpButton.Pressed && isGrounded())
        {
            jump = true;
            rb.velocity += Vector3.up * 5f;
        } 

        else if (jump  && !jumpButton.Pressed)
        {
            jump = false;
        }
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

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);
    }

    void TimerUpdate()
    {
        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString();
        timerText.text = minutes + ":" + seconds;
    }
    
    void SetLifesText()
    {
        lifesText.text = "Lifes: " + lifes.ToString();
    }

    void StopMovement()
    {
        playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }


}