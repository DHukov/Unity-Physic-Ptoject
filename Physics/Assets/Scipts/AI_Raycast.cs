using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Raycast : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Enemy;
    [SerializeField] Transform raycast;



    public float speed;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        float r = Random.Range(-180f, 180f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.DrawRay(raycast.position, raycast.forward * distance, Color.black);

        if (isPlayer())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);

        }
        if (!isFloor())
        {
            transform.rotation = Quaternion.Euler(0, r, 0);
        }


    }
    bool isPlayer()
    {
        return Physics.Raycast(transform.position, Enemy.transform.forward, distance);
    }
    bool isFloor()
    {
        return Physics.Raycast(raycast.position, raycast.forward, distance);
    }
}
