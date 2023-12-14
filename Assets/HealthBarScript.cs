using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    GameObject demon;

    DemonScript demonScript;

    Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        demonScript = demon.GetComponent<DemonScript>();
        healthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = demonScript.health / 100f;
    }
}
