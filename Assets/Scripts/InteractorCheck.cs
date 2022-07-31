using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorCheck : MonoBehaviour
{
    private float Radius = 2f;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
