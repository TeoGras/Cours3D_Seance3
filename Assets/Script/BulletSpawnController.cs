using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnController : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletHandler;
    [SerializeField] private float spawnForceModifier = 1f;
    

    public void SpawnBullet() {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, bulletHandler);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * spawnForceModifier);
        audio.Play();
    }
    
}
