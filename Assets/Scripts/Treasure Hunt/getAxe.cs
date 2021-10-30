using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getAxe : MonoBehaviour
{
    BoxCollider2D box;
    public static bool gotAxe = false;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("slot"))
        {
            transform.parent = collision.transform;
            transform.position = collision.transform.position;
            gotAxe = true;
        }
    }

    private void Update()
    {
        
    }
}
