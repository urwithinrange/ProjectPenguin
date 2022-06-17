using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnShuffler : MonoBehaviour
{
    // the spawn points. lol.
    public GameObject[] spawnPoints;

    // the enemy prefab.
    public GameObject womper;
    public GameObject[] womp;

    //the time between spawns.
    public float spawnDelay = 5f;

    public Text DebugText;

    /// <summary>
    /// Start. Um. Start.
    /// </summary>
    public void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        // spawn an enemy every 2 seconds
        // InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    /// <summary>
    /// Upd8
    /// </summary>
    public void Update()
    {
        GameObject[] womp = GameObject.FindGameObjectsWithTag("Enemy");
        if (womp.Length > 9)
        {
            DebugText.text = "Enemies: " + womp.Length;
            // CancelInvoke("SpawnEnemy");
        }
        else
        {
            Instantiate(womper, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Shuffles the spawn points. Simple stuff.
    /// </summary>
    public void ShuffleSpawnPoints()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject temp = spawnPoints[i];
            int randomIndex = Random.Range(i, spawnPoints.Length);
            spawnPoints[i] = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = temp;
        }
    }

    /// <summary>
    /// Spawns enemies in the most recently shuffled spawn point.
    /// </summary>
    public void SpawnEnemy()
    {
        ShuffleSpawnPoints();
        GameObject spawnPoint = spawnPoints[1];
        GameObject enemy = Instantiate(womper, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    /// <summary>
    /// Ui grab that loads the UI scene
    /// </summary>
    public void EatTheBigMushroom()
    {
        SceneManager.LoadScene(0);
    }
}
