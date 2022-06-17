using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem.XR;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ProjectileShoot : MonoBehaviour
{
    public string triggerButton;

    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;

    [SerializeField] private Transform barrelLocation;
    [SerializeField] private float destroyTimer = 1f;
    [SerializeField] private float BulletSpeed = 500f;

    // [SerializeField] private AudioSource BulletCollisionAudio; 
    // [SerializeField] private AudioSource BulletFireAudio;

    // [SerializeField] private static float ScoreText;
    // [SerializeField] private Text ScoreTextText;

    void Start()
    {
        //Set the barrel location to the gun barrel
        // ScoreTextText = GameObject.Find("ScoreTextText").GetComponent<Text>();
        // ScoreTextText.text = "Get started honky";
    }

    void Update()
    {
        if (Input.GetButtonDown(triggerButton))
        {
            Shoot();
        }
        // ScoreTextText.text = "Score: " + ScoreText;
    }
    public void Shoot()
    {
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            // BulletFireAudio.Play();
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed);
    }

    // public void OnCollisionEnter(Collision other)
    // {
    //     // BulletCollisionAudio.Play();
    //     if (other.gameObject.tag == "Enemy")
    //     {
    //         ScoreTextText.text = "Collision achieved";
    //         // Destroy(other.gameObject);
    //         ScoreText += Random.Range(1, 3);
    //     }
    // }
}
