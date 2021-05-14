using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float fireRate = 10f;
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 5f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0) 
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload() 
    {
        isReloading = true;
        Debug.Log("Reload");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
    void Shoot() 
    {
        muzzleFlash.Play();
        RaycastHit hit;

        currentAmmo--;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) 
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null) 
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
