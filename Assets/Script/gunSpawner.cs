/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunSpawnPoint;
    private int spawnTimer = 5;
    private float resetTimer = 0f;
    private bool canSpawn = true;
    private Coroutine spawnCoroutine = null;//stop multiple coroutines from running

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnGun();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (canSpawn == false)
    //    {
    //        resetTimer += 1 * Time.deltaTime;
    //        if (resetTimer >= spawnTimer)
    //        {
    //            canSpawn = true;
    //            resetTimer = 0;
    //            SpawnGun();
    //        }
    //    }
    //}
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
            if (spawnCoroutine == null)
            {
                spawnCoroutine = StartCoroutine(StartSpawnTimer());
            }
        }
        
    }
    private IEnumerator StartSpawnTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnTimer);
        canSpawn = true;
        SpawnGun();
        spawnCoroutine = null;
    }
}*/
using System.Collections;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunSpawnPoint;
    private float spawnTimer = 5f;
    private bool canSpawn = true;
    private Coroutine spawnCoroutine = null;
    //private GameObject currentGun = null; // Track the spawned gun

    void Start()
    {
        SpawnGun(); // Spawn the gun at start
    }

    private void SpawnGun()
    {
        if (canSpawn)
        {
            //float randomZ = Random.Range(0, 4);
            //float randomY = Random.Range(0, 4);

            //// Set the gun's position with the random Y value
            //Vector3 spawnPosition = new Vector3(gunSpawnPoint.position.x, randomY, gunSpawnPoint.position.z);

            Instantiate(gunPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);//gunSpawnPoint.position
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("blaster"))
        {
            //currentGun = null; // Clear reference
            if (spawnCoroutine == null)
            {
                spawnCoroutine = StartCoroutine(StartSpawnTimer());
            }
        }
    }

    private IEnumerator StartSpawnTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnTimer);
        canSpawn = true;
        
        SpawnGun(); // Spawn a new gun after timer ends
        spawnCoroutine = null;
    }
}
