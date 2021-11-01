using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class008_SimpleBlockSpawn : MonoBehaviour
{
    public GameObject blockPrefab;

    private void Start()
    {
        //control the Random with the same starting seed 
        //Random.InitState(7);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float x = Random.Range(-8.0f, 8.0f); //lowest float is -80.0f
            float y = Random.Range(-5.0f, 5.0f);
            GameObject B = Instantiate(blockPrefab, new Vector3(x, y), Quaternion.identity);
        }
    }
}
