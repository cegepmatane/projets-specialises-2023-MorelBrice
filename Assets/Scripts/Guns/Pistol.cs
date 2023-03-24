using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    public float damage = 10f;

    public float range = 100f;

    public Camera fpsCam;

    public AudioClip gunFire;
    public AudioClip reloading;
    public AudioSource gunAudioSource;

    float timeStamp;
    ParticleSystem muzzleFlash;

    private float gunShotCoolDown = 0.5f;

    private float reloadingTime = 3.37f;

    private float MagazineCapacity = 6.0f;

    private float remainingBullets;

    void Start()
    {
        gunAudioSource = GetComponent<AudioSource>();
        
        muzzleFlash = GetComponent<ParticleSystem>();
        remainingBullets = MagazineCapacity;

        AmmoUIScript.AmmoValue = MagazineCapacity;
    }

    // Update is called once per frame
    void Update()
    {

        AmmoUIScript.AmmoValue = remainingBullets;

       if (Input.GetKeyDown(KeyCode.Mouse0) && timeStamp <= Time.time && remainingBullets >= 1)
       {
            Shoot();
       }

       if (Input.GetKeyDown(KeyCode.R))
       {
            Reload();
            gunAudioSource.PlayOneShot(reloading);
       }
    }

    void Shoot ()
    {
        muzzleFlash.Play();

        // gunFire.Play();
        gunAudioSource.PlayOneShot(gunFire);

        remainingBullets -= 1;

        // Debug.Log(remainingBullets);

        timeStamp = Time.time + gunShotCoolDown;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
        }
        
    }

    void Reload()
    {
        timeStamp = Time.time + reloadingTime;
        remainingBullets = MagazineCapacity;
    }
}
