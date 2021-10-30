using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSetPos : MonoBehaviour
{

    //public Vector3 pos;
    public Camera cam;

    public BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        //cam = GetComponent<Camera>();
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player success");
            cam.transform.position += new Vector3(0, -11.16f, -10);
            //pos.y += -11.16f;
        }
        if (collision.CompareTag("Player_2nd"))
        {
            Debug.Log("Phase two success");
            cam.transform.position += new Vector3(18.31f, -9.16f, -10);
        }
    }

}
