using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public float deadRadius = 2.4f;
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -19.81f;
    public float jumpHeight = 3f;
    public float stamina = 100f;
    public Transform enemy;
    public Transform groundCheck;
    public Transform treeCheck;
    public Transform treeCheck1;
    public Transform treeCheck2;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;
    public AudioSource audioData;
    public AudioSource audioData2;

    Vector3 velocity;
    bool isGrounded;
    bool isTouched;
    bool isTouched1;
    bool isTouched2;
    bool isMoved = false;
    bool isPlayed = false;
    bool isPlayed2 = false;
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        isTouched = Physics.CheckSphere(treeCheck.position, groundDistance, groundmask);

        if (isTouched)
        {
            if (velocity.x < 0 || velocity.z < 0)
            {
                velocity.y = -2f;
            }

        }
        isTouched2 = Physics.CheckSphere(treeCheck2.position, groundDistance, groundmask);

        if (isTouched2)
        {
            if (velocity.x < 0 || velocity.z < 0)
            {
                velocity.y = -2f;
            }

        }
        isTouched1 = Physics.CheckSphere(treeCheck1.position, groundDistance, groundmask);

        if (isTouched1)
        {
            if (velocity.x < 0 || velocity.z < 0)
            {
                velocity.y = -2f;
            }

        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float x_old = 0f;
        float z_old = 0f;
        if (x != x_old || z != z_old)
        {
            x_old = x;
            z_old = z;
            isMoved = true;
        }
        else if (x == x_old && z == z_old)
        {
            isMoved = false;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if (isGrounded == true && isMoved == false && audioData.isPlaying == true)
        {
            audioData.Pause();
            audioData2.Pause();
        }
        if (isGrounded == false && audioData.isPlaying == true)
        {
            audioData.Pause();
            audioData2.Pause();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            speed += 10f;
            if (isGrounded == true && isMoved == true && audioData2.isPlaying == false && isPlayed2 == false)
            {
                audioData2.Play();
                isPlayed2 = true;
            }
            else if (isGrounded == true && isMoved == true && audioData2.isPlaying == false && isPlayed2 == true)
            {
                audioData2.UnPause();
            }

        }
        if (Input.GetButtonUp("Fire3"))
        {
            speed -= 10f;
            if (isGrounded == true && isMoved == true && audioData2.isPlaying == true)
            {
                audioData2.Pause();
            }
        }

        if (!Input.GetButtonDown("Fire3"))
        {
            if (isGrounded == true && isMoved == true && audioData.isPlaying == false && isPlayed == false)
            {
                audioData.Play();
                isPlayed = true;
            }
            else if (isGrounded == true && isMoved == true && audioData.isPlaying == false && isPlayed == true)
            {
                audioData.UnPause();
            }
            else if (isGrounded == true && isMoved == false && audioData.isPlaying == true)
            {
                audioData.Pause();

            }
        }
        float distance = Vector3.Distance(enemy.position, transform.position);
        if (distance <= deadRadius)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}