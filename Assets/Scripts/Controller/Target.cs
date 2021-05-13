using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 20f;
    public ParticleSystem effect;
  //  public ParticleSystem hitEffect;

    public void TakeDamage(float amount) 
    {
        // hitEffect.Play();
        effect.Play();
        health -= amount;
        if(health <= 0f) 
        {
            
            Die();
        }
    }

    void Die() 
    {
        
        Destroy(gameObject);
    }
}
