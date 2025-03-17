using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunSpawnPoint;
    private int spawnTimer = 5;
    private float resetTimer = 0f;
    private bool canSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnGun();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn == false)
        {
            resetTimer += 1 * Time.deltaTime;
            if (resetTimer >= spawnTimer)
            {
                canSpawn = true;
                resetTimer = 0;
                SpawnGun();
            }
        }
    }
    public void SpawnGun()
    {
        if (canSpawn == true)
        {
            Instantiate(gunPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("item");
        if (other.CompareTag("blaster"))
        {
            SpawnGun();
        }
        canSpawn = false;
    }
}
