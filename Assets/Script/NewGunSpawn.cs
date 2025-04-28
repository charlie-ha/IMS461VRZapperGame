using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class NewGunSpawn : MonoBehaviour
{

    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunSpawnPoint;
    [SerializeField] public GameObject player;
    
    public UnityEvent onPressGun;
    public UnityEvent onReleaseGun;
    GameObject gun;

    bool isGrabbed;



    void Start()
    {

        isGrabbed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isGrabbed)
        {
            
            gun = other.gameObject;
            onPressGun.Invoke();

            isGrabbed = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == gun)
        {
          
            onReleaseGun.Invoke();
            isGrabbed = false;
            
        }
    }

    public void SpawnNewGun()
    {
        Instantiate(gunPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);
    }

}
    
