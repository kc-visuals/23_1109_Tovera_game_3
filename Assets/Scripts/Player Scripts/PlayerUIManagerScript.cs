using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIManagerScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ammoUI;

    GameObject player;

    ShootingScript shootingScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootingScript = player.GetComponent<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoUI.text = shootingScript.ammo + " / 6";
    }
}
