using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public int targetSpawnAmount = 3;
    [SerializeField] private GameObject targetPrefabs;
    public float spawnTimer = 20;//every 10s, changeable
    private float resetTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resetTimer += 1 * Time.deltaTime;
            if(resetTimer >= spawnTimer)
            {
                //canSpawn = true;
                resetTimer = 0;
                SpawnTargets();
            }
    }

    void SpawnTargets()
    {
        for(int i = 0; i < targetSpawnAmount; i++)
        {
            int spawnRandom = Random.Range(0, spawnPoints.Length);//random positions near spawn points
            Instantiate(targetPrefabs, new Vector3(spawnPoints[spawnRandom].position.x - Random.Range(0, 3), spawnPoints[spawnRandom].position.y, spawnPoints[spawnRandom].position.z - Random.Range(0, 5)), spawnPoints[i].rotation);//which points to spawn; positions; rotation
        }
    }
}
