using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Class008_SimpleBlockSpawnTwo : MonoBehaviour
{
    System.Random r;
    public GameObject blockPrefab;

    private void Start()
    {
        r = new System.Random();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float x = (float)(r.NextDouble() * (8.0f -  (-8.0f)) + (-8.0f));
            float y = (float)(r.NextDouble() * (5.0f - (-5.0f)) + (-5.0f));
            GameObject b = Instantiate(blockPrefab, new Vector3(x, y), Quaternion.identity);
        }
    }
}
