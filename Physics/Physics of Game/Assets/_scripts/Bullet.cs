using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //при коалішене
    private void OnCollisionEnter(Collision collision)
    {
        // если колизия с врагом
        if (collision.transform.tag == "enemy")
        {
            //уничтажается обьект (враг)
            Destroy(collision.gameObject);
        }
        //наш геймобджект, тобишь пуля становиться неактивной и исчезает
        gameObject.SetActive(false);
    }
}
