using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;


    private GameObject ChoosItem()
    {
        return items[Random.Range(0, items.Count)];
    }
    public void SpawnItem(Vector2 pos)
    {
        if (Random.Range(0, 100) >= 20) return;
        GameObject item = ChoosItem();
        Instantiate(item, pos, Quaternion.identity);
    }
}
