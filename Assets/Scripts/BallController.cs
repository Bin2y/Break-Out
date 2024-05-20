using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballSpeed = 500f;
    public bool isBallShoot;
    public Transform Paddle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!isBallShoot)
        {
            transform.position = Paddle.position;
        }

        if (Input.GetMouseButtonDown(0) && !isBallShoot)
        {
            isBallShoot = true;
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            Vector2 launchDirection = new Vector2(x, 1).normalized;
            rb.AddForce(launchDirection * ballSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            isBallShoot = false;
            rb.velocity = Vector2.zero;
        }
    }
}
