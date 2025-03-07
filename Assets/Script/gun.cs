using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        //create bullet at fire point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //get rigidbody component from the bullet to apply force
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if(rb != null)
        {
            //add force to bullet
            rb.AddForce(firePoint.forward*bulletForce, ForceMode.Impulse);
        }

    }
}
