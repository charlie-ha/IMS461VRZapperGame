//using UnityEngine;
//using System.Collections;
//using UnityEngine.Events;

//public class NewGunSpawn : MonoBehaviour
//{

//    [SerializeField] private GameObject gunPrefab;
//    [SerializeField] private Transform gunSpawnPoint;
//    [SerializeField] public GameObject player;

//    public UnityEvent onPressGun;
//    public UnityEvent onReleaseGun;
//    GameObject gun;

//    public bool isGrabbed;



//    void Start()
//    {

//        isGrabbed = false;
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (!isGrabbed && other.tag == "Hands")
//        {

//            gun = other.gameObject;
//            onPressGun.Invoke();

//            isGrabbed = true;
//            Debug.Log(other.transform.name);
//        }
//    }


//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject == gun && other.tag == "Hands")
//        {

//            onReleaseGun.Invoke();
//            isGrabbed = false;
//            StartCoroutine(DestroyGun(other.gameObject));
//        }
//    }

//    public void SpawnNewGun()
//    {
//        Instantiate(gunPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);
//    }
//    private IEnumerator DestroyGun(GameObject gun)
//    {
//        yield return new WaitForSeconds(5f);
//        if(gun && isGrabbed == false)
//        {
//            Destroy(gun);
//        }
//    }
//}

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class NewGunSpawn : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunSpawnPoint;
    [SerializeField] private GameObject player;

    public UnityEvent onPressGun;
    public UnityEvent onReleaseGun;

    private GameObject currentGunParent;
    private bool isGrabbed;

    void Start()
    {
        isGrabbed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGrabbed && other.CompareTag("Hands")) // or adjust to your target collider tag
        {
            SpawnNewGun();
            onPressGun.Invoke();
            isGrabbed = true;

            Debug.Log("Gun grabbed by: " + transform.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isGrabbed && other.CompareTag("Hands")) // same tag check as above
        {
            onReleaseGun.Invoke();
            isGrabbed = false;

            if (currentGunParent != null)
                StartCoroutine(DestroyGunParentAfterDelay(currentGunParent));
        }
    }

    public void SpawnNewGun()
    {
        GameObject spawnedGun = Instantiate(gunPrefab, gunSpawnPoint.position, gunSpawnPoint.rotation);
        currentGunParent = spawnedGun.transform.parent != null ? spawnedGun.transform.parent.gameObject : spawnedGun;
    }

    private IEnumerator DestroyGunParentAfterDelay(GameObject gunParent)
    {
        yield return new WaitForSeconds(5f);

        if (!isGrabbed && gunParent != null)
        {
            Destroy(gunParent);
        }
    }
}