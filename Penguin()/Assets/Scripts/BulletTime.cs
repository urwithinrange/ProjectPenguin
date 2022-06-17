using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BulletTime : MonoBehaviour
{
    public GameObject DodgeThis;
    public GameObject coinPrefab;

    [SerializeField] private AudioSource BulletCollisionAudio; 
    [SerializeField] private AudioSource BulletFireAudio;

    void Start()
    {
        BulletFireAudio.Play();
        Destroy(DodgeThis, 3);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(coinPrefab, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        // Destroy(collision.gameObject);
        Destroy(DodgeThis);
        BulletCollisionAudio.Play();
        /// Able to add animation or Damage here
        // Debug.Log("Collided with " + collision.gameObject.name);
    }
}
