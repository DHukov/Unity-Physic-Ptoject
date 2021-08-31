using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    float bulletSpeed = 1000f;
    public GameObject bullet;
    public float TimeLive = 3f;
    AudioSource shootSound;

    void Start()
    {
        // берем звук с самого начала
        shootSound = GetComponent<AudioSource>();
    }
    void Fire()
    {
        // создаём обьект и даём ему силу полёта в указано точке
        GameObject tempBullet = Instantiate(bullet, SpawnPoint.position, SpawnPoint.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        // уничтожаем пулю после 1 сек
        Destroy(tempBullet, TimeLive);
        // проигрываем звук
        shootSound.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
}
