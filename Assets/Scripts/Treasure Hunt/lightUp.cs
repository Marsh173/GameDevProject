using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightUp : MonoBehaviour
{
    BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
