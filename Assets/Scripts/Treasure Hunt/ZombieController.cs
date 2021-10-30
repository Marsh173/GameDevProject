using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ZombieController : MonoBehaviour
{
    private Rigidbody2D rb;
    CapsuleCollider2D cap;
    BoxCollider2D box;

    [SerializeField] private string End;

    public TMP_Text pillCount;

    public float speed;
    public float jump_strength;

    private float moveX;

    [SerializeField]
    bool isGrounded;
    bool canJump;

    //Aninmation
    private Animator anim;

    //pills
    public static int count = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cap = GetComponent<CapsuleCollider2D>();
        box = GetComponent<BoxCollider2D>();
        pillCount.text = "Goal: Get Green Pills: " + count + "/5";
    }

    void jumpUp()
    {
        if(!isGrounded)
        {
            return;
        }

        isGrounded = false;

        rb.AddForce(Vector2.up * jump_strength, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
            Debug.Log(collision.gameObject.name, collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Medicine"))
        {

        }
    }


    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if(canJump)
        {
            canJump = false;
            jumpUp();
        }
    }

    private void Update()
    {

        if(moveX == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        if (moveX < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (moveX > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
            anim.SetBool("isJumping", true);
        }

        if (Input.GetKey(KeyCode.C))
        {
            canJump = false;
            anim.SetBool("isCrouching", true);
            box.enabled = true; //change collider
            cap.enabled = false;

            //change position 
        }
        else
        {
            anim.SetBool("isCrouching", false);
            box.enabled = false;
            cap.enabled = true;
        }



        pillCount.text = "Goal: Get Green Pills: " + count + "/5";

        if(count>= 5)
        {
            SceneManager.LoadScene(End);
        }

    }

        
}
