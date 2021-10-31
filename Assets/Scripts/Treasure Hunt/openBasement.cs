using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class openBasement : MonoBehaviour
{
    [SerializeField]
    private TMP_Text openDoor;

    public GameObject axe;

    BoxCollider2D box;

    private AudioSource audioSource;
    bool close_to_door;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        close_to_door = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        openDoor.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(close_to_door && Input.GetKeyDown(KeyCode.E))
        {
            open();
        }
    }

    void open()
    {
        audioSource.Play();
        Destroy(gameObject,0.4f);
        Destroy(axe,0.4f);
        openDoor.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!getAxe.gotAxe)
            {
                openDoor.gameObject.SetActive(true);
                openDoor.text = "The door's stuck.";
                close_to_door = false;
            }
            else
            {
                openDoor.gameObject.SetActive(true);
                openDoor.text = "Crack it open!";
                close_to_door = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            openDoor.gameObject.SetActive(false);
            close_to_door = false;
        }
    }



}
