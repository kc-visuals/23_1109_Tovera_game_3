using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnInteract()
    {
        Debug.Log("interact");
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitData;
        if(Physics.Raycast(ray, out hitData, 3, layerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawRay(ray.origin, ray.direction);
            if (hitData.transform.CompareTag("journal"))
            {
                Debug.Log(hitData.transform.name);
                hitData.transform.gameObject.GetComponent<bookScript>().OpenJournal();
            }
            if (hitData.transform.CompareTag("sphere"))
            {
                hitData.transform.gameObject.GetComponent<sphereScript>().breakSphere();
            }
        }
        
    }

}
