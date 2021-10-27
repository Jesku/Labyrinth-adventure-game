using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmootTime = 0.1f;
    float turnSmoothVelocity;
    public float explodeVolume = 3.0f;
    public float winnerVolume = 5.0f;
    private AudioSource playerAudio;
    public AudioClip explodeSound;
    public AudioClip winnerSound;
    private Animator playerAnim;
    public bool run = false;

    private GameManager gameManager;


    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmootTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            playerAnim.SetBool("run", true);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            run = true;
        }

        else
        {
            run = false;
            playerAnim.SetBool("run", false);
        }


    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ButtonRed"))
        {
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Wall Red"));
            playerAudio.PlayOneShot(explodeSound, explodeVolume);
            gameManager.RedWallOpen();
            
        }

        if (other.gameObject.CompareTag("ButtonYellow"))
        {
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Wall Yellow"));
            playerAudio.PlayOneShot(explodeSound, explodeVolume);
            gameManager.YellowWallOpen();
        }

        if (other.gameObject.CompareTag("ButtonBlue"))
        {
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Wall Blue"));
            playerAudio.PlayOneShot(explodeSound, explodeVolume);
            gameManager.BlueWallOpen();
        }

        if (other.gameObject.CompareTag("ButtonPink"))
        {
            Destroy(other.gameObject);
            Destroy(GameObject.Find("Wall Pink"));
            playerAudio.PlayOneShot(explodeSound, explodeVolume);
            gameManager.PinkWallOpen();
        }

        if (other.gameObject.CompareTag("Trophy"))
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(winnerSound, winnerVolume);
            gameManager.PlayFireworks();
        }
        
    }
    
}
