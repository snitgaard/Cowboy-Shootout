using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChasePlayer : MonoBehaviour
{
    public float speed;
    public float damage = 1.0f;

    public Collider playerCollider;
    public Transform target;
    public Text result;
    
    private ExitMenu exitMenuObject;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        exitMenuObject = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ExitMenu>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player(Clone)");
    }
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
            exitMenuObject.gameOver();
            result = GameObject.Find("Canvas/gameOver/Result").GetComponent<Text>();    
            result.text = "You died. The Cowboys caught you";
    }
}
