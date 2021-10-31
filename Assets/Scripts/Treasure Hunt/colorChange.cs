using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colorChange : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pressE;

    public static bool pickUp;
    CapsuleCollider2D capCollider;
    //SpriteRenderer spriteRender;

    public AudioSource audioSource;
    private void Awake()
    {
        capCollider = GetComponent<CapsuleCollider2D>();
        capCollider.isTrigger = true;
        audioSource = GetComponent<AudioSource>();

       // spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        pressE.gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void Update()
    {
        if(pickUp && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Play();
            DoPickUp();
            pressE.gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            pressE.gameObject.SetActive(true);
            pickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            pressE.gameObject.SetActive(false);
            pickUp = false;
        }
    }

    void DoPickUp()
    {
        Destroy(gameObject,0.3f);
        Door.unlock = true;
        
    }

}
