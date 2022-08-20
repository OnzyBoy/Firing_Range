using UnityEngine;
using TMPro;

public class GunControls : MonoBehaviour
{
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;
    private AudioSource gunSource;
    public AudioClip gunShotClip;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public float range = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        gunSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            gunSource.PlayOneShot(gunShotClip, 1f);
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        muzzleFlash.Play();
        //shooting from camera's position to where the camera is facing
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //if statement that shoots sth
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if(target != null) //check for objects with target component
            {
                target.DeleteObject();  
            }
            ParticleSystem impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, .2f);
            
        }
    }

}
