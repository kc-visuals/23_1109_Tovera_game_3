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

    [SerializeField]
    float reloadTime;

    public int ammo = 6;
    bool readyToFire;

    [SerializeField]
    float shotTimeFloat;

    WaitForSeconds shotTime;

    private void Start()
    {
        shotTime = new WaitForSeconds(shotTimeFloat);
        readyToFire = true;
    }
    void OnFire()
    {
        if (readyToFire)
        {
            if (ammo > 0)
            {
                Instantiate(bullet, gun.transform.position, mainCamera.transform.rotation);
                ammo--;
                readyToFire = false;
                StartCoroutine(ShotDelay());
            }
        }
    }

    void OnReload()
    {
        StartCoroutine(ReloadCoroutine());
        //play particle effect for reload spell
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        ammo = 6;
    }

    IEnumerator ShotDelay()
    {
        yield return shotTime;
        readyToFire = true;
    }
}
