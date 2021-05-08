using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    private Vector3 projectileOffset;
    private Rigidbody playerRb;
    private float speed = 30f;
    public CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //float verticalInput = Input.GetAxis("Vertical");
       // playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
      /*  if (Input.GetKeyDown(KeyCode.Space)) 
        {
            projectileOffset = new Vector3(0, 1, 0);
            Instantiate(projectilePrefab, transform.position + projectileOffset, projectilePrefab.transform.rotation);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey("a")) 
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey("w")) 
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey("s")) 
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }*/
    }
}
