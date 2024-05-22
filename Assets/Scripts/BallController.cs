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
            GameManager.instance.BallCount--; //볼이 떨어질시에 볼카운트 감소
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector2 vel = rb.velocity;
        float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        if (0f <= angle && angle < 30f)
        {
            angle = 30f;
        }
        else if (-30f < angle && angle <= 0f)
        {
            angle = -30f;
        }
        else if (-180f <= angle && angle <= 150f)
        {
            angle = -150f;
        }
        else if (150f < angle && angle < 180f)
        {
            angle = 150f;
        }
    }
}
