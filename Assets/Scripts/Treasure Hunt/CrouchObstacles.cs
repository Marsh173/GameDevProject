using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrouchObstacles : MonoBehaviour
{
    public TMP_Text warning;
    CircleCollider2D circle;

    private void Awake()
    {
        warning.gameObject.SetActive(false);
    }
    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            warning.gameObject.SetActive(true);
            warning.text = "Simple reaction Test beyond. C to crouch.";
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            warning.gameObject.SetActive(false);
        }
    }


}
