using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float lifetime;

    [SerializeField]
    float gravityMultiplier;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    int dmgAmount;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, lifetime);   
    }

    private void Update()
    {
        Gravity();
    }

    void Gravity()
    {
        rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Demon"))
        {
            collision.gameObject.GetComponent<DemonScript>().Damage(dmgAmount);
        }
    }
}
