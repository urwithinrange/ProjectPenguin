using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestro : MonoBehaviour
{

    public LayerMask whatIsGround, whatIsEnemy, whatIsWater;

    public bool enemyInSightRange, groundInSightRange, waterInSightRange;
    public float sightRange = .01f;
    // public var hit : RaycastHit;
    public RaycastHit hit;

    // public Audiosource Deathrattle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);
        groundInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsGround);
        waterInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsWater);

        if (enemyInSightRange) Death();
        if (!enemyInSightRange && waterInSightRange && !groundInSightRange) Destroy(gameObject);
        if (!enemyInSightRange && !waterInSightRange && groundInSightRange) Destroy(gameObject);
    }

    private void Death()
    {

        Destroy(gameObject);

        // delete the object hit by the raycast
        if (Physics.Raycast(transform.position, transform.forward, out hit, sightRange))
        {
            if (hit.collider.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

}
