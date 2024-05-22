using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    //아이템 프리펩을 받아서 처리
    [SerializeField] private List<GameObject> items;


    private GameObject ChoosItem()
    {
        return items[Random.Range(0, items.Count)];
    }
    public void SpawnItem(Vector2 pos)
    {
        GameObject item = ChoosItem();
        if (GameObject.Find(item.name) != null) return;
        //if (Random.Range(0, 100) >= 20) return;
        item = Instantiate(item, pos, Quaternion.identity);
        RemoveCloneText(item);
    }

    //Instantiate시에 생기는 Clone없애기
    protected void RemoveCloneText(GameObject item)
    {
        int index = item.name.IndexOf("(Clone)");
        if (index > 0)
        {
            item.name = item.name.Substring(0, index);
        }
    }
}
