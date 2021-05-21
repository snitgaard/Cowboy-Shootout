using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float jumpHeight = 2.0f;
    public float groundDistance = 0.4f;
    public float gravity = -4.00f;

    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    private float speed = 30f;
    private GameObject powerUp;
    private bool powerUpped;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded || Input.GetButtonDown("Jump") && powerUpped == true) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        powerUp = GameObject.Find("PowerUp(Clone)");
        if (other.gameObject.tag == "PowerUp")
            Destroy(powerUp);
            powerUpped = true;
            yield return new WaitForSeconds(5.0f);
            powerUpped = false;
    }
}
