using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereScript : MonoBehaviour
{
    [SerializeField]
    GameObject text1;

    [SerializeField]
    GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(true);
        text2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void breakSphere()
    {
        text1.SetActive(false);
        text2.SetActive(true);
        Debug.Log("breaksphere");
        Destroy(gameObject);
    }
}
