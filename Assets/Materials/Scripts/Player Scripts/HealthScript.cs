using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    GameObject youDied;

    WaitForSeconds WFSregenSpeed;
    WaitForSeconds WFSregenCD;

    bool alive;

    Coroutine regenCDcoroutine;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        WFSregenCD = new WaitForSeconds(regenCooldown);
        WFSregenSpeed = new WaitForSeconds(regenSpeed);
        health = maxHealth;
        alive = true;
        //youDied.SetActive(false);
    }

    private void Update()
    {
        if(health <= 0 && alive)
        {
            Death();
        }
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

    void Death()
    {
        alive = false;
        //Time.timeScale = 0;
        Instantiate(youDied);
        //Transform panel = youDied.transform.GetChild(0);
        //panel.gameObject.GetComponent<Animator>().Play("youDiedFade");
        StartCoroutine(DeathScreenCoroutine());
    }

    IEnumerator DeathScreenCoroutine()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
