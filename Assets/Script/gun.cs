using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(LineRenderer))]
public class gun : MonoBehaviour
{
    //public GameObject bulletPrefab;
    //[SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject hitMarker;
    [SerializeField] private Transform gunHead;
    [SerializeField] private GameObject brokenTargetPrefab; // Prefab for broken target

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip[] gunSounds;
    [SerializeField] private Text ammoCount;
    public Transform firePoint;
    public Camera playerCamera;

    //laser gun
    public float gunRange = 100f;
    public float laserDuration = 0.5f;

    LineRenderer laserLine;

    private int ammo = 10;
    private int maxAmmo =20;
    //public float bulletForce = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammo = maxAmmo;
        //ammoCount.text = "Ammo: " + ammo;
        audioPlayer = GetComponent<AudioSource>();
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        if (ammo > 0)
        {
            //muzzleFlash.SetActive(true);
            //create bullet at fire point position and rotation
            //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            //get rigidbody component from the bullet to apply force
            //Rigidbody rb = bullet.GetComponent<Rigidbody>();

            //if (rb != null)
            //{
            //    //add force to bullet
            //    rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            //}
            if (!audioPlayer.isPlaying)
                {
                    audioPlayer.clip = gunSounds[0];//shoot
                    audioPlayer.pitch = Random.Range(0.8f, 1.2f);
                    audioPlayer.Play();
                }
            ammo--;
            laserLine.SetPosition(0, firePoint.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            //ammoCount.text = "Ammo" + ammo;
            // Ray ray = Camera.main.ViewportPointToRay(
            //     new Vector3(0.5f, 0.5f, 0f) //50% width, 50% height; how to show Raycast: show the ray
            // );
            Ray ray = new Ray(gunHead.position, gunHead.forward);


            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo))
            {
                //true - if ray is intersected
                //false - if not intersected
                //send hit information into hitInfo variable
                //hitInfo.point position it is hit

                //Debug.Log("We've shot" + hitInfo.point);
                laserLine.SetPosition(1, hitInfo.point);
                GameObject hitObject = hitInfo.collider.gameObject;
                Debug.Log(hitObject.name);
                // if (hitObject.name == "intact_target" || hitObject.layer == LayerMask.NameToLayer("target"))
                // {
                //     // Spawn broken target at the same position and rotation
                //     GameObject brokenTarget = Instantiate(brokenTargetPrefab, hitObject.transform.position, hitObject.transform.rotation);
                //     Destroy(hitObject); // Remove the intact target
                // }
                // GameObject marker = Instantiate(hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                // // Instantiate returns the reference (memory add) of the cloned item
                // Destroy(marker,2.0f);

                //replace broken targets
                targetBreak targetBreak = hitObject.GetComponent<targetBreak>();
                if(targetBreak != null)
                {
                    targetBreak.Break();
                }
                // target C = hitInfo.transform.GetComponent<intact_target>(); 
                // if(C != null)
                //     C.Destroy();
            
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
        }
        if (ammo<=0) 
        {
            //dry fire
            if (!audioPlayer.isPlaying || audioPlayer.clip != gunSounds[1])
            {
                audioPlayer.clip = gunSounds[1]; // Dry fire sound
                audioPlayer.pitch = Random.Range(0.8f, 1.2f);
                audioPlayer.Play();
            }
        }
        
    }
}
