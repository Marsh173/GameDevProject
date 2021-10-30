using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveObject()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((Vector2.left * speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((Vector2.right * speed * Time.deltaTime));
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }
}
