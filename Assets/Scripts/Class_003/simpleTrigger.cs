using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleTrigger : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    SpriteRenderer spriteRender;
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        spriteRender = GetComponent<SpriteRenderer>();
    }

    //example. 
 /*   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player success");
            //Debug.LogWarning("WarningTest!");
            collision.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
        /*

        if(collision.GetComponent<BoxCollider2D>())
        {
            Debug.Log("Player success!");
        } */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player success");
            collision.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }

    //OnTriggerEnter2D + OnTriggerExit2D

    // for physics: do fixedUpdate
    void FixedUpdate()
    {
        
    }
}
