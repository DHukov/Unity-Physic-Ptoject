using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movee_Hero : MonoBehaviour
{

    public float SensitiveX = 3f;
    public float MinX = -360f;
    public float MaxX = 360f;
    private Quaternion originalRot;
    private float rotX = 0;


    [SerializeField] Rigidbody rb;
    [SerializeField] Transform raycastOrigin;

    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float SideSpeed = 1f;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float DistancRaycstJump = 0.1f;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        originalRot = transform.localRotation;
    }
    void Update()
    {



        rotX += Input.GetAxis("Mouse X") * SensitiveX;
        rotX = rotX % 360;
        rotX = Mathf.Clamp(rotX, MinX, MaxX);
      
        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        transform.localRotation = originalRot * xQuaternion;


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * SideSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        transform.Translate(x, y: 0, z) ; 
 
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
