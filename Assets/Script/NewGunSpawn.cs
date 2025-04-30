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
        if (!isGrabbed && other.tag == "Hands")
        {
            
            gun = other.gameObject;
            onPressGun.Invoke();

            isGrabbed = true;
            Debug.Log(gun);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == gun && other.tag == "Hands")
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
    
