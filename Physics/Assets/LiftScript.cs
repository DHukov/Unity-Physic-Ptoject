using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    public GameObject Elewator;
    public GameObject Player;


    void Start()
    { 

    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("There");
    }
}
