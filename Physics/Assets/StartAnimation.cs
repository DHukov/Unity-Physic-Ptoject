using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
        //anim.enabled = false;
        // anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.enabled = true;
            anim.Play("Base Layer.Elewator", 0, 1);
        }
        else
        {
            //anim.enabled = false;

        }
    }
}
