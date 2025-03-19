using UnityEngine;

public class GunDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blaster"))
        {
            Destroy(other.gameObject);
        }
    }
}
