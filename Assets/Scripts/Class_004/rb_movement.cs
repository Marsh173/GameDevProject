using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rb_movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float jump_strength = 5.0f;
    float move_speed = 5.0f;
    float moveX;

    [SerializeField]
    bool isGrounded; //or bool isGrounded, canJump 
    bool canJump;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void playerControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }

        moveX = Input.GetAxis("Horizontal");
    }

    void jump()
    {
        if (!isGrounded)
            return;


        Debug.Log("Jump!");
        isGrounded = false;

        rb.AddForce(Vector2.up * jump_strength, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //can use tag to specify collision gameObject.
        isGrounded = true;
        Debug.Log(collision.gameObject.name, collision.gameObject);
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(moveX * move_speed, rb.velocity.y);


        if (canJump)
        {
            canJump = false;
            jump();
        }
    }

    private void Update()
    {
        playerControl();
    }

}
