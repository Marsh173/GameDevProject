using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public int speed = 1;

    public Sprite normal;
    public Sprite change;
    
    void Start()
    {
        
    }

    void playerMove()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate((Vector2.right * Time.deltaTime) * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate((Vector2.right * Time.deltaTime) * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((Vector2.up * Time.deltaTime) * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector2.down * Time.deltaTime) * speed);
        }
    }

    void Update()
    {
        playerMove();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().sprite = change;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().sprite = normal;
        }

    }
}
