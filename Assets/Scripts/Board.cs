using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject bricks;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.StageInit(bricks);

    }
}
