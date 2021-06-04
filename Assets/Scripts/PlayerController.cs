using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 2.0f;
    public Rigidbody playerRb;
    private float jumpForce = 5.0f;
    public float horizontalInput;
    private float xRange = 12.0f;
    public int collisions = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, 0, -9.8f);

        Debug.Log("Number of Collision: " +  collisions);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.forward * jumpForce, ForceMode.Impulse);
        }

        ConstraintPlayerPosition();

        if (collisions == 3)
        {
            Debug.Log("Game Over!");
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerRb.AddForce(Vector3.forward * jumpForce, ForceMode.Impulse);
        } else if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * 10.0f, ForceMode.Impulse);
            collisions++;
            Debug.Log("Number of Collision: " + collisions);
        }
    }

    void ConstraintPlayerPosition()
    {
        if (transform.position.z > 4.8)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 4.8f);
        }

        if (transform.position.z < -4.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4.5f);
            Debug.Log("Game Over!");
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
