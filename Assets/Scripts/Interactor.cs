using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    private int key_number = 0;
    public GameObject textUI;
    public GameObject key_1;
    public GameObject key_2;
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] private Transform _interactionpoint;
    public Transform key1;
    public Transform key2;
    public Transform key3;
    public float distance1;
    public float distance2;
    public float distance3;
    bool checkObject_1 = true;
    bool checkObject_2 = true;
    bool checkObject_3 = true;
    // Update is called once per frame
    void Update()
    {
        distance1 = Vector3.Distance(key1.position, _interactionpoint.position);
        if (distance1 <= 1f && checkObject_1)
        {
            textUI.SetActive(true);
            if (Input.GetKeyDown("e")) {
                key_1.SetActive(false);
                checkObject_1 = false;
                key_number += 1;
            }
        }
        else {
           textUI.SetActive(false);
        }
        distance2 = Vector3.Distance(key2.position, _interactionpoint.position);
        if (distance2 <= 1f && checkObject_2)
        {
            textUI.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                key_2.SetActive(false);
                checkObject_2 = false;
                key_number += 1;
            }
        }
        else
        {
            textUI.SetActive(false);
        }


    }

}
