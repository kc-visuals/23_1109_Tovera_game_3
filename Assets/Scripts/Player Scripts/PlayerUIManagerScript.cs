using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerUIManagerScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ammoUI;

    
    VolumeProfile volumeProfile;

    [SerializeField]
    Volume volume;

    Vignette redVignette;

    GameObject player;

    ShootingScript shootingScript;

    HealthScript healthScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthScript = player.GetComponent<HealthScript>();
        shootingScript = player.GetComponent<ShootingScript>();

        volumeProfile = volume.sharedProfile;

        volumeProfile.TryGet(out redVignette);
        redVignette.intensity.value = 3;
    }

    // Update is called once per frame
    /*void Update()
    {
        ammoUI.text = shootingScript.ammo + " / 6";
        if(healthScript.health < 40)
        {
            
        }
    }*/
}
