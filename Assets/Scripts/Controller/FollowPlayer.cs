using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private float speed = 450;

    void Start()
    {

    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position;
    }
}