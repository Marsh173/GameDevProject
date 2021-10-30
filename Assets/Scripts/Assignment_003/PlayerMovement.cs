using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rb1;

    private void Awake()
    {
        rb.simulated = false;
        rb1.simulated = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.simulated = true;
            rb1.simulated = true;
        }
    }
}
