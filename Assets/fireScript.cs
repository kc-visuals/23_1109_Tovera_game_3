using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScript : MonoBehaviour
{
    [SerializeField]
    float burnCooldown;

    [SerializeField]
    int burnDamage;

    bool readyToBurn;

    // Start is called before the first frame update
    void Start()
    {
        readyToBurn = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && readyToBurn)
        {
            other.gameObject.GetComponent<HealthScript>().Damage(burnDamage);
            readyToBurn = false;
            StartCoroutine(BurnCooldown());
        }
    }

    IEnumerator BurnCooldown()
    {
        yield return new WaitForSeconds(burnCooldown);

        readyToBurn = true;
    }
}
