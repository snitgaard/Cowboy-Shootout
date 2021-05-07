using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Vector3 projectileOffset;
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(projectilePrefab, transform.position + projectileOffset, projectilePrefab.transform.rotation);
        }
    }
}
