
using System.Collections;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform[] gunSpawnPoints;
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

            Instantiate(gunPrefab, gunSpawnPoints[0].position, gunSpawnPoints[0].rotation);//gunSpawnPoint.position
            Instantiate(gunPrefab, gunSpawnPoints[1].position, gunSpawnPoints[1].rotation);//gunSpawnPoint.position
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
