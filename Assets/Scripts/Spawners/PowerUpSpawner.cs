using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUp, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
