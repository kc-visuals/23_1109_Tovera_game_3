using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject demon;

    [SerializeField]
    float demonTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DemonSpawnTimer());
    }

    IEnumerator DemonSpawnTimer()
    {
        yield return new WaitForSeconds(demonTimer);

        Instantiate(demon, transform.position, transform.rotation, transform);
    }
}
