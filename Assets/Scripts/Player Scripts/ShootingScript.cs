using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    GameObject gun;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject mainCamera;

    void OnFire()
    {
        Instantiate(bullet, gun.transform.position, mainCamera.transform.rotation);
    }
}
