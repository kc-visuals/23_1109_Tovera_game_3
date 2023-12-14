using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int health;

    [SerializeField]
    int maxHealth;

    [SerializeField]
    float regenCooldown;

    [SerializeField]
    float regenSpeed;

    [SerializeField]
    int regenAmount;


    WaitForSeconds WFSregenSpeed;
    WaitForSeconds WFSregenCD;

    Coroutine regenCDcoroutine;
    // Start is called before the first frame update
    void Start()
    {
        WFSregenCD = new WaitForSeconds(regenCooldown);
        WFSregenSpeed = new WaitForSeconds(regenSpeed);
        health = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if(regenCDcoroutine != null)
        {
            StopCoroutine(regenCDcoroutine);
        }
        regenCDcoroutine = StartCoroutine(RegenCooldownCoroutine());

    }

    void Regen()
    {
        health += regenAmount;
    }

    IEnumerator RegenCoroutine()
    {
        while(health < maxHealth)
        {
            Regen();
            yield return WFSregenSpeed;
        } 
    }

    IEnumerator RegenCooldownCoroutine()
    {
        yield return WFSregenCD;
        StartCoroutine(RegenCoroutine());
    }
}
