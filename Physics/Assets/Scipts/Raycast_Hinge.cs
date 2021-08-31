using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Hinge : MonoBehaviour
{ 
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform raycast;



    public float speed;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        float r = Random.Range(-180f, 180f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.DrawRay(raycast.position, raycast.forward * distance, Color.black);

   
        if (!isFloor())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);
        }


    }
 
    bool isFloor()
    {
        return Physics.Raycast(raycast.position, raycast.forward , distance);
    }
    
}
