using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    private float speed = 10.0f;
    private float xRange = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        ConstraintEnemyPosition();
    }

    void ConstraintEnemyPosition()
    {
        if (transform.position.z > 4.8 || transform.position.z < -4.5 || transform.position.x < -xRange || transform.position.x > xRange)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}
