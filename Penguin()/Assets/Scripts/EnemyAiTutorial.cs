using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public GameObject CoconutSpawn;
    public AudioSource audioSource;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Extra pieces of the scene
    public AudioSource DeathRattle;
    public GameObject coinPrefab;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        // Debug.Log("player In Sight Range = " + playerInSightRange);
        // Debug.Log("Player in attack Range = " + playerInAttackRange);
    }

    private void Patroling()
    {
        agent.SetDestination(player.position);
        // Debug.Log("Patroling");
        // if (!walkPointSet) SearchWalkPoint();
            // Debug.Log("walk point not set");
        // if (walkPointSet)
            // agent.SetDestination(walkPoint);

        // Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        // if (distanceToWalkPoint.magnitude < 1f)
        //     walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        // Debug.Log("Searching for walkpoint");
        //Calculate random point in range
        // float randomZ = Random.Range(-walkPointRange, walkPointRange);
        // float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = player.position.z;
        float randomX = player.position.x;

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        // Debug.Log("Walkpoint = " + walkPoint);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        // Debug.Log("Chasing player");
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // Debug.Log("Attacking player");
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Debug.Log("Attack count: " + i);
            ///Attack code here

            Rigidbody rb = Instantiate(projectile, CoconutSpawn.transform.position, Quaternion.identity).GetComponent<Rigidbody>();  // simulate an arm
            audioSource.Play();
            // Rigidbody rb = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.60f), Quaternion.identity).GetComponent<Rigidbody>();
            // Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            // rb.AddForce((player.position - transform.position).normalized * 20f, ForceMode.Impulse);
            // rb.AddForce(transform.up * 3f, ForceMode.Impulse);
            rb.AddForce(transform.TransformDirection(new Vector3 (-.05f, .05f, 1)) * 20f, ForceMode.Impulse);

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        DeathRattle.Play();
        Destroy(gameObject);
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    ///<summary>
    /// Checks the AI's damage intake
    ///</summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            DestroyEnemy();
            // TakeDamage(10);
            var spwn = gameObject.GetComponent<SpawnShuffler>();
            spwn.SpawnEnemy();
        }
    }
}
