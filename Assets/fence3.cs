using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fence3 : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.LookAt(target);
    }
}
