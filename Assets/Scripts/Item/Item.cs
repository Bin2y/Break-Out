using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //패들과 충돌시
        if (collision.tag.Equals("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            ApplyItem(collision);
        }
    }

    protected virtual void ApplyItem(Collider2D collision) { }

}
