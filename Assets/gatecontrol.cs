using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatecontrol : MonoBehaviour
{
    public CharacterController controller;
    public float currentTime = 0f;
    public Vector3 rotateDirection;
    public float rotationSpeed = 80f;
    // Start is called before the first frame update
    void Start()
    {

        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentTime <= 2f)
        {
            currentTime += 1 * Time.deltaTime;
            if (currentTime < 1.1f)
            {
                rotateDirection = new Vector3(0, 1, 0);
            }
            else if (currentTime >= 1.1f)
            {
                rotateDirection = new Vector3(0, 0, 0);
            }
        }
        transform.Rotate(rotateDirection * rotationSpeed * Time.deltaTime);
    }
}
