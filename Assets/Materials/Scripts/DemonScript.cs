using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DemonScript : MonoBehaviour
{
    [SerializeField]
    float jumpAttackTime;

    [SerializeField]
    GameObject particle;
    private GameObject particleInstance;

     bool alive;
    public bool invulnerable;
    public bool isAttacking;
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    Rigidbody rb;

    public int health;

    [SerializeField]
    int maxHealth;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    [SerializeField]
    int damageAmount;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    Animator anim;

    public void Awake()
    {
        alive = true;
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        health = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Debug.Log("test");

        if (!isAttacking)
        {
            //if (!playerInSightRange && !playerInAttackRange) Patrolling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }

        if (health <= 0 && alive)
        {
            //anim.applyRootMotion = true;
            anim.Play("blank");

            Instantiate(particle, transform.position, transform.rotation, transform);
            alive = false;
            StartCoroutine(Death());
            // gameObject.SetActive(true);
        }


    }

    
    private void OnCollisionStay(Collision collision)
    {
        if (isAttacking)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<HealthScript>().Damage(damageAmount);
            }
        }
    }

    void Patrolling()
    {
        //Debug.Log("patrol");
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint Reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    void ChasePlayer()
    {
        Debug.Log("chase");
        agent.SetDestination(player.position);
    }
    void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        if(!alreadyAttacked)
        {
            //AttackCode
            Debug.Log("ATTACK");
            agent.enabled = false;
            isAttacking = true;
            anim.SetBool("attacking", true);
            StartCoroutine(JumpAttackCoroutine());
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            rb.AddForce(transform.forward * 700 + transform.up * 200);
            


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator JumpAttackCoroutine()
    {
        yield return new WaitForSeconds(jumpAttackTime);
        isAttacking = false;
        anim.SetBool("attacking", false);
        agent.enabled = true;
        rb.freezeRotation = false;
    }

    public void Damage(int damageAmount)
    {
        if (!invulnerable)
        {
            health -= damageAmount;
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
