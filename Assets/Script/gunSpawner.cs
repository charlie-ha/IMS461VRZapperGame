using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunSpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnGun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnGun()
    {
        Instantiate(gunPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);
    }
    private void OnTriggerExit(Collider other)
    {
        SpawnGun();
    }
}
