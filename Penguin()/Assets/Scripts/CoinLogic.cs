using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class CoinLogic : MonoBehaviour
{
    public NavMeshAgent coin;
    public Transform player;
    public float sightRange;
    public float colRange;
    public LayerMask whatIsPlayer, whatIsGround;
    public bool playerInSightRange;
    public bool collectionRange;
    public GameObject bullion;
    public AudioSource coinSound;
    public Text RichesText;
    public static int Riches;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        coin = GetComponent<NavMeshAgent>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        RichesText = GameObject.Find("RichesText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bullion.transform.Rotate(Vector3.forward * (240 * Time.deltaTime));
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (playerInSightRange)
        {
            ChasePlayer();
        }
        collectionRange = Physics.CheckSphere(transform.position, colRange, whatIsPlayer);
        if (collectionRange)
        {
            coinSound.Play();
            // call collect function
            Riches += 1;
            Destroy(gameObject);

        }
        RichesText.text = "Riches: " + Riches;
    }

    private void ChasePlayer()
    {
        coin.SetDestination(player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, colRange);
    }
}
