using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onGrass : MonoBehaviour
{
    public static bool IsOnGrass;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsOnGrass = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IsOnGrass = false;
        }
    }
}
