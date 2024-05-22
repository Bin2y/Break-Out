using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            //이미지만 끈다
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            ApplyItem(collision);
        }
    }
    protected virtual void ApplyItem(Collider2D collision) { }
   
}
