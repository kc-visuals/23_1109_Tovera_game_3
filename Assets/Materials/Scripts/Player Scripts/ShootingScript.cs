using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    AudioSource audio;

    [SerializeField]
    GameObject gun;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject mainCamera;

    [SerializeField]
    float reloadTime;

    [SerializeField]
    GameObject reloadParticle;

    public int ammo = 6;
    bool readyToFire;

    [SerializeField]
    float shotTimeFloat;

    WaitForSeconds shotTime;

    private void Start()
    {
        shotTime = new WaitForSeconds(shotTimeFloat);
        readyToFire = true;
        audio = GetComponent<AudioSource>();
    }
    void OnFire()
    {
        if (readyToFire)
        {
            if (ammo > 0)
            {
                Instantiate(bullet, gun.transform.position, mainCamera.transform.rotation);
                audio.Play();
                ammo--;
                readyToFire = false;
                StartCoroutine(ShotDelay());
            }
        }
    }

    void OnReload()
    {
        StartCoroutine(ReloadCoroutine());
        Instantiate(reloadParticle, gun.transform.position, gun.transform.rotation, gun.transform);
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
