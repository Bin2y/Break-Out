using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendPaddleItem : Item
{
    private Vector3 originalScale;
    protected override void ApplyItem(Collider2D collision)
    {
        originalScale = collision.gameObject.transform.localScale;
        collision.gameObject.transform.localScale += new Vector3(2f, 0, 0);
        StartCoroutine(ResetScale(collision));
    }

    IEnumerator ResetScale(Collider2D collision)
    {
        //10초동안 커졌다가 작아짐
        yield return new WaitForSecondsRealtime(10);
        collision.gameObject.transform.localScale = originalScale;
        Destroy(gameObject);
    }
}