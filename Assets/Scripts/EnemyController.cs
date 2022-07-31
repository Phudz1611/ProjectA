using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public float currentTime = 0f;
    float startingTime = 0f;
    Animator animator;
    public float lookRadius = 50f;
    public float runspeed = 19f;
    public float speed = 20f;
    public CharacterController controller;
    public float rotationSpeed = 80f;
    public Vector3 rotateDirection;
    public Transform target;
    public Transform limitpoint;
    public Transform object_house;

    bool isTouched;

    public Transform object_tent;

    bool isTouched1;

    public LayerMask groundmask;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {

        isTouched = Physics.CheckSphere(object_house.position, 0.4f, groundmask);
        isTouched1 = Physics.CheckSphere(object_tent.position, 0.4f, groundmask);
        float distance = Vector3.Distance(target.position, transform.position);
        float distance1 = Vector3.Distance(limitpoint.position, transform.position);
        float distance2 = Vector3.Distance(object_house.position, transform.position);
        float distance3 = Vector3.Distance(object_tent.position, transform.position);
        if (distance <= lookRadius && distance > 2.4f)
        {
            animator.SetBool("isRunning", true);
            if (distance1 < 998f && distance2 > 14f)
            {
                Vector3 move = -target.forward;
                currentTime = 0f;
                controller.Move(move * runspeed * Time.deltaTime);
                transform.LookAt(target);
                rotateDirection = new Vector3(0, 0, 0);
            }
            else if (distance1 >= 998f)
            {
                currentTime += 1 * Time.deltaTime;
                if (currentTime >= 1f)
                {
                    if (currentTime < 5f)
                    {
                        rotateDirection = new Vector3(0, 0, 0);
                    }
                    else if (currentTime >= 5f)
                    {
                        rotateDirection = new Vector3(0, 1, 0);
                    }
                    Vector3 move2 = transform.forward;
                    controller.Move(move2 * speed * Time.deltaTime);
                }
                else if (currentTime < 1f)
                {
                    rotateDirection = new Vector3(0, 1, 0);
                }
                transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);
            }
            else if (distance2 <= 14f && isTouched)
            {
                currentTime += 1 * Time.deltaTime;
                if (currentTime >= 1f)
                {
                    if (currentTime < 5f)
                    {
                        rotateDirection = new Vector3(0, 0, 0);
                    }
                    else if (currentTime >= 5f)
                    {
                        rotateDirection = new Vector3(0, 1, 0);
                    }
                    Vector3 move2 = transform.forward;
                    controller.Move(move2 * speed * Time.deltaTime);
                }
                else if (currentTime < 1f)
                {
                    rotateDirection = new Vector3(0, 1, 0);
                }
                transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);



            }
            else if (distance3 <= 12f && isTouched1)
            {
                currentTime += 1 * Time.deltaTime;
                if (currentTime >= 1f)
                {
                    if (currentTime < 5f)
                    {
                        rotateDirection = new Vector3(0, 0, 0);
                    }
                    else if (currentTime >= 5f)
                    {
                        rotateDirection = new Vector3(0, 1, 0);
                    }
                    Vector3 move2 = transform.forward;
                    controller.Move(move2 * speed * Time.deltaTime);
                }
                else if (currentTime < 1f)
                {
                    rotateDirection = new Vector3(0, 1, 0);
                }
                transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);

            if (distance1 < 998f && distance2 > 15f)
            {
                Vector3 move1 = transform.forward;
                currentTime = 0f;
                controller.Move(move1 * speed * Time.deltaTime);
                rotateDirection = new Vector3(0, 0, 0);
            }
            else if (distance1 >= 998f)
            {
                currentTime += 1 * Time.deltaTime;
                if (currentTime >= 1f)
                {
                    if (currentTime < 5f)
                    {
                        rotateDirection = new Vector3(0, 0, 0);
                    }
                    else if (currentTime >= 5f)
                    {
                        rotateDirection = new Vector3(0, 1, 0);
                    }
                    Vector3 move2 = transform.forward;
                    controller.Move(move2 * speed * Time.deltaTime);
                }
                else if (currentTime < 1f)
                {
                    rotateDirection = new Vector3(0, 1, 0);
                }
                transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);
            }
            else if (distance2 <= 15f)
            {
                currentTime += 1 * Time.deltaTime;
                if (currentTime >= 1f)
                {
                    if (currentTime < 5f)
                    {
                        rotateDirection = new Vector3(0, 0, 0);
                    }
                    else if (currentTime >= 5f)
                    {
                        rotateDirection = new Vector3(0, 1, 0);
                    }
                    Vector3 move2 = transform.forward;
                    controller.Move(move2 * speed * Time.deltaTime);
                }
                else if (currentTime < 1f)
                {
                    rotateDirection = new Vector3(0, 1, 0);
                }
                transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);
            }
            else if (distance3 <= 12f && isTouched1)
            {
                currentTime += 1 * Time.deltaTime;
                if (currentTime >= 1f)
                {
                    if (currentTime < 5f)
                    {
                        rotateDirection = new Vector3(0, 0, 0);
                    }
                    else if (currentTime >= 5f)
                    {
                        rotateDirection = new Vector3(0, 1, 0);
                    }
                    Vector3 move2 = transform.forward;
                    controller.Move(move2 * speed * Time.deltaTime);
                }
                else if (currentTime < 1f)
                {
                    rotateDirection = new Vector3(0, 1, 0);
                }
                transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);
            }
        }


        
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }

    }
}
