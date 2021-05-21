using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    public float fireRate = 10f;
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float reloadTime = 3f;
    public int maxAmmo = 10;
    public int currentAmmo;
    public int enemiesKilled = 0;
    
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public Animator animator;

    public Text currentAmmoText;
    public Text enemiesKilledText;
    public Text result;

    private bool isReloading = false;
    private float nextTimeToFire = 0f;
    private ExitMenu exitMenuObject;
    
    void Start()
    {
        exitMenuObject = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ExitMenu>();
        enemiesKilledText = GameObject.Find("Canvas/UI/EnemiesKilled").GetComponent<Text>();
        enemiesKilledText.text = "Killed Enemies:" + " " + enemiesKilled;
        currentAmmoText = GameObject.Find("Canvas/UI/Ammo").GetComponent<Text>();
        currentAmmoText.text = "" + currentAmmo + "/" + maxAmmo;
        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled == 15) 
        {
            exitMenuObject.gameOver();
            result = GameObject.Find("Canvas/gameOver/Result").GetComponent<Text>();
            result.text = "Congratulations you won. You killed :" + enemiesKilled;
        }
        enemiesKilledText.text = "Killed Enemies:" + " " + enemiesKilled;
        currentAmmoText.text = "" + currentAmmo + "/" + maxAmmo;
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
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) 
            {
                if(target.TakeDamage(damage) == 0) 
                {
                }
                else
                {
                    enemiesKilled++; 
                }
            }
            if (hit.rigidbody != null) 
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
