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

    public bool isGrabbed;



    void Start()
    {

        isGrabbed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isGrabbed && other.tag == "blaster")
        {
            
            gun = other.gameObject;
            onPressGun.Invoke();

            isGrabbed = true;
            Debug.Log(other.transform.name);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == gun && other.tag == "blaster")
        {
          
            onReleaseGun.Invoke();
            isGrabbed = false;
            StartCoroutine(DestroyGun(other.gameObject));
        }
    }

    public void SpawnNewGun()
    {
        Instantiate(gunPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);
    }
    private IEnumerator DestroyGun(GameObject gun)
    {
        yield return new WaitForSeconds(5f);
        if(gun && isGrabbed == false)
        {
            Destroy(gun);
        }
    }
}
    
