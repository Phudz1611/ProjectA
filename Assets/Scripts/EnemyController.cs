using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public float currentTime = 0f;
    public float checkTime = 0f;
    float startingTime = 0f;
    Animator animator;
    public float lookRadius = 50f;
    public float runspeed = 19f;
    public float speed = 20f;
    public CharacterController controller;
    public float rotationSpeed = 80f;
    public Vector3 rotateDirection;
    public Vector3 velocity;
    public Transform target;
    public Transform limitpoint;
    public bool isMove;
    float x;
    float z;
    float x_old;
    float z_old;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        currentTime = startingTime;
        checkTime = startingTime;
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            animator.SetBool("isRunning", true);
            rotateDirection = new Vector3(0, 0, 0);
            if (isMove)
            {
                Vector3 move = transform.forward;
                currentTime = 0f;
                controller.Move(move * runspeed * Time.deltaTime);
                transform.LookAt(target);
                
            }
            else if (!isMove)
            {

                currentTime += 1 * Time.deltaTime;
                if (currentTime <= 6f)
                {
                    if (currentTime < 2f)
                    {
                        rotateDirection = new Vector3(0, 1, 0);
                    }
                    else if (currentTime >= 2f && currentTime <5f)
                    {
                        rotateDirection = new Vector3(0, 0, 0);
                        Vector3 move2 = transform.forward;
                        controller.Move(move2 * speed * Time.deltaTime);
                    }
                    else if (currentTime >= 5f) {
                        x = transform.position.x;
                        z = transform.position.z;
                    }

                    transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);

                }
            }
            
        }
        else
        {
            animator.SetBool("isRunning", false);
            rotateDirection = new Vector3(0, 0, 0);
            if (isMove)
            {
                Vector3 move1 = transform.forward;
                currentTime = 0f;
                controller.Move(move1 * speed * Time.deltaTime);
                
            }
            if (!isMove)
            {

                currentTime += 1 * Time.deltaTime;
                if (currentTime <= 3.5f)
                {
                    if (currentTime < 2f)
                    {
                        rotateDirection = new Vector3(0, 1, 0);
                    }
                    else if (currentTime >= 2f)
                    {
                        rotateDirection = new Vector3(0, 0, 0);
                        Vector3 move2 = transform.forward;
                        controller.Move(move2 * speed * Time.deltaTime);
                    }
                    transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);

                }


            }

            x = transform.position.x;
            z = transform.position.z;
        }
        if (x != x_old || z != z_old)
        {
            x_old = x;
            z_old = z;
            isMove = true;
            checkTime = 0f;
        }
        else if (x == x_old && z == z_old)
        {
            checkTime += 1 * Time.deltaTime;
            if (checkTime > 2f)
            { 
                isMove = false;
            }
            
        }
        
    }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }

    
}
