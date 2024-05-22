using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSlowItem : Item
{
    //본래의 속도를 담는다.
    private float originalBallSpeed;
    protected override void ApplyItem(Collider2D collision)
    {
        BallController ball = GameObject.Find("Ball").GetComponent<BallController>();
        originalBallSpeed = ball.ballSpeed;
        ball.ballSpeed = 250f;
        ball.ApplyBallMovement(ball.transform.up);
        StartCoroutine(ResetBallSpeed(ball));
    }

    IEnumerator ResetBallSpeed(BallController ball)
    {
        yield return new WaitForSeconds(6f);
        ball.ballSpeed = originalBallSpeed;
        ball.ApplyBallMovement(ball.transform.up);
        Destroy(gameObject);
        
    }
}