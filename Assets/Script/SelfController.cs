using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfController : MonoBehaviour
{
    [SerializeField] private BulletSpawnController bulletSpawnController;
    
    private float _yawn = 0f;
    private float _pitch = 0f;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float _mouseSensitivity = 1f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        ChangePosition();
        ChangeCameraRotation();
        FireBulletControl();

    }

    private void ChangePosition()
    {
        /*
         * Fonction qui permet de changer la position de la caméra/joueur en fonction des touches appuyés
         */
        Vector3 deltaPosition = (transform.right * Input.GetAxis("Horizontal") 
                                 + transform.forward * Input.GetAxis("Vertical"))
                                *Time.deltaTime*speed;
        deltaPosition.y = 0f;

        transform.position += deltaPosition;
    }

    private void ChangeCameraRotation()
    {
        /*
         * Fonction qui permet de tourner la caméra suivant les mouvements de la souris
         */
        _yawn += Input.GetAxis("Mouse X") * _mouseSensitivity;
        _pitch -= Input.GetAxis("Mouse Y") * _mouseSensitivity;
        _pitch = Mathf.Clamp(_pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(_pitch, _yawn, 0f);
    }
    private void FireBulletControl()
    {
        /*
         * Fonction qui permet de tirer
         */
        if (Input.GetButtonUp("Fire1"))
            bulletSpawnController.SpawnBullet();
    }
}
