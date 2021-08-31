using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movee_Hero : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] Transform raycastOrigin;



    [Range(1f, 100f)] [SerializeField] float movementSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float DistancRaycstJump = 0.3f;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100f * rotationSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime  * movementSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    
        if (Input.GetKeyDown(KeyCode.Space)  && canIjump())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    bool canIjump()
    {
        return Physics.Raycast(raycastOrigin.position, direction: Vector3.down, DistancRaycstJump);
    }
   
}
