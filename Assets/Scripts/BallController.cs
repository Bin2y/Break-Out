using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ballSpeed = 500f;
    public bool isBallShoot;
    public Transform Paddle;
    Vector2 launchDirection;

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
            launchDirection = new Vector2(x, 1).normalized;
            ApplyBallMovement(launchDirection);
        }
    }

    //진행중인 방향으로 힘을 주도록한다. 속도가 바뀌면 해당 함수를 이용하면 velocity를 0으로 만들었다가 다시 발사하는 방식
    public void ApplyBallMovement(Vector2 dir)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(dir * ballSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            isBallShoot = false;
            rb.velocity = Vector2.zero;
            GameManager.instance.ballCount--; //볼이 떨어질시에 볼카운트 감소
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
        else if (-180f <= angle && angle < -150f)
        {
            angle = -150f;
        }
        else if (150f < angle && angle <= 180f)
        {
            angle = 150f;
        }
        angle *= Mathf.Deg2Rad;
        rb.velocity = rb.velocity.magnitude * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
