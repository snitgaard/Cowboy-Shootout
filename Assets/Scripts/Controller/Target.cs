using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 20f;
    public ParticleSystem bloodEffect;
  //  public ParticleSystem hitEffect;

    public int TakeDamage(float amount) 
    {
        // hitEffect.Play();
        
        health -= amount;
        if(health <= 0f) 
        {
            
            Die();
            return 1;
        }
        else
        {
            return 0;
        }
    }

    void Die() 
    {
        Instantiate(bloodEffect, transform.position, transform.rotation).Play();
        Destroy(gameObject);
    }
}
