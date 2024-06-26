using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    ItemHandler itemHandler;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemHandler = GameObject.Find("ItemHandler").GetComponent<ItemHandler>();
    }

    public void SettingBrick(int num)
    {
        switch (num)
        {
            case 1:
                spriteRenderer.color = Color.gray;
                break;
            case 2:
                spriteRenderer.color = Color.red;
                break;
            case 3:
                spriteRenderer.color = Color.yellow;
                break;
            case 4:
                spriteRenderer.color = Color.blue;
                break;
            case 5:
                spriteRenderer.color = Color.magenta;
                break;
            case 6:
                spriteRenderer.color = Color.green;
                break;
            case 7:
                spriteRenderer.color = Color.cyan;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        GameManager.instance.BrickCount--;
        GameManager.instance.currentScore += 50;
        itemHandler.SpawnItem(gameObject.transform.position); 
        Debug.Log("brickCount : " + GameManager.instance.BrickCount);
    }
}
