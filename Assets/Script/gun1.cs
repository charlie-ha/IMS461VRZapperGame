using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun1 : MonoBehaviour
{
    //automatic rifle
    //public GameObject bulletPrefab;
    //[SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject hitMarker;
    [SerializeField] private Transform gunHead;
    [SerializeField] private GameObject brokenTargetPrefab; // Prefab for broken target

    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip[] gunSounds;
    [SerializeField] private Text ammoCount;
    [SerializeField] private GameObject laser;
    [SerializeField] private ParticleSystem muzzleFlash;

    //public Transform firePoint;
    //public Camera playerCamera;

    //laser gun
    //public float gunRange = 100f;
    //public float laserDuration = 0.5f;

    //LineRenderer laserLine;

    private int ammo = 20;
    private int maxAmmo = 40;
    private bool isShooting = false;
    private Coroutine shootingCoroutine;
    public float fireRate = 0.1f; // Time between shots

    //public float bulletForce = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammo = maxAmmo;
        //ammoCount.text = "Ammo: " + ammo;
        audioPlayer = GetComponent<AudioSource>();
        //laserLine = GetComponent<LineRenderer>();
        laser.SetActive(false);
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        //muzzleFlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //public void activateGun()
    //{
    //    isShooting = true;
    //}
    //public void deactivateGun()
    //{
    //    isShooting = false;
    //}
    public void activateGun()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootingRoutine());
        }
    }

    public void deactivateGun()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
            isShooting = false;
        }
    }

    public void Shoot()
    {
        if (ammo > 0)
        {
            laser.SetActive(true);
            StartCoroutine(DisableLaserAfterDelay(0.05f)); // Start coroutine to turn it off after 0.1s

            muzzleFlash.Play(); // Show muzzle flash
            StartCoroutine(DisableMuzzleFlashAfterDelay(0.1f)); // Hide muzzle flash after 0.05s

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
            audioPlayer.Stop();
            if (!audioPlayer.isPlaying)
                {
                    audioPlayer.clip = gunSounds[0];//shoot
                    audioPlayer.pitch = Random.Range(0.8f, 1.2f);
                    audioPlayer.Play();
                }
            ammo--;
            //laserLine.SetPosition(0, firePoint.position);
            //Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

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
                //laserLine.SetPosition(1, hitInfo.point);
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
            //else
            //{
            //    laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            //}
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
    private IEnumerator DisableLaserAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        laser.SetActive(false); // Turn off laser
    }
    private IEnumerator DisableMuzzleFlashAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        muzzleFlash.Stop();
    }
    private IEnumerator ShootingRoutine()
    {
        isShooting = true;
        while (isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }
}
