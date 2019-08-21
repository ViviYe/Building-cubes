using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    GameObject currentBlock;
    [SerializeField] public GameObject[] blocks;
    [SerializeField] public Camera mainCam;
    public static bool next;

    void Start()
    {
        GenerateNewBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (next)
        {
            next = false;
            GenerateNewBlock();
        }
        
    }


    void GenerateNewBlock()
    {
        Vector2 startingPos = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 1f);
        currentBlock = blocks[Random.Range(0, blocks.Length)];
        Instantiate(currentBlock, startingPos, Quaternion.identity);
    }


    public static void Next()
    {
        next = true;
    }

}
