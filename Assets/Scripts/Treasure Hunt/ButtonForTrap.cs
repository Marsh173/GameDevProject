using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonForTrap : MonoBehaviour
{
    [SerializeField] private TMP_Text pressE;

    CircleCollider2D cap;

    public GameObject trap;

    bool pressButton;

    private AudioSource audioSource;

    private void Awake()
    {
        cap = GetComponent<CircleCollider2D>();
        cap.isTrigger = true;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        pressE.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(pressButton && Input.GetKeyDown(KeyCode.E))
        {
            DoPress();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            pressE.gameObject.SetActive(true);
            pressButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressE.gameObject.SetActive(false);
            pressButton = false;
        }
    }

    void DoPress()
    {
        audioSource.Play();
        Destroy(trap);
        pressE.gameObject.SetActive(false);
    }
}
