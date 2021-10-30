using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMove : MonoBehaviour
{
    public Rigidbody2D rb;
    bool moveLeft = false;

    bool moveRight;
    public float power = 1.0f;

    void MoveControls()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        moveRight = Input.GetKey(KeyCode.RightArrow);
    }

    void Update()
    {
        MoveControls();
    }

    private void FixedUpdate()
    {
        
        if(moveLeft)
        {
            rb.AddForce(Vector2.left * power);
            //rb.AddForce(new Vector2(-1.0f, 0.0f)); equivalent with above
        }

        if(moveRight)
        {
            rb.AddForce(Vector2.right * power);
        }

    }
}
