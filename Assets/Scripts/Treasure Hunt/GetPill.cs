using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPill : MonoBehaviour
{
    [SerializeField]
    private TMP_Text EtoGet;

    bool pickUp;
    CapsuleCollider2D cap;

    private void Awake()
    {
        cap = GetComponent<CapsuleCollider2D>();
        cap.isTrigger = true;  
    }

    private void Start()
    {
        EtoGet.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(pickUp && Input.GetKeyDown(KeyCode.E))
        {
            getPill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EtoGet.gameObject.SetActive(true);
            pickUp = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EtoGet.gameObject.SetActive(false);
            pickUp = false;
        }
    }

    void getPill()
    {
        Destroy(gameObject);
        ZombieController.count++;
    }


}
