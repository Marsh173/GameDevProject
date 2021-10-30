using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField]
    private TMP_Text locked;
    [SerializeField]
    private TMP_Text unlock_door;

    private BoxCollider2D boxCollider;

    bool close_to_door;

    public GameObject the_actual_door;
    public GameObject barn_floor;


    public static bool unlock = false;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        locked.gameObject.SetActive(false);
        unlock_door.gameObject.SetActive(false);
        barn_floor.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(close_to_door && Input.GetKeyDown(KeyCode.E))
        {
            Open();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!unlock)
            {
                locked.gameObject.SetActive(true);
                unlock_door.gameObject.SetActive(false);
                close_to_door = false;
            }
            else if (unlock)
            {
                unlock_door.gameObject.SetActive(true);
                locked.gameObject.SetActive(false);
                close_to_door = true;
                //unlock = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //unlock = false;
            locked.gameObject.SetActive(false);
            unlock_door.gameObject.SetActive(false);
            close_to_door = false;
        }
    }

    void Open()
    {
        Destroy(gameObject);
        Destroy(the_actual_door);
        barn_floor.gameObject.SetActive(true);
        
    }




}
