using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class ChasePlayer : MonoBehaviour
{
    public float speed;

    private Rigidbody enemyRb;

    private GameObject player;
    public Collider playerCollider;
    public Transform target;

    public float damage = 1.0f;
    private ExitMenu exitMenuObject;
    // Start is called before the first frame update
    void Start()
    {
        exitMenuObject = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ExitMenu>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }

        if (transform.position.y < -10) 
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            exitMenuObject.playerLost();
        

    }
}
