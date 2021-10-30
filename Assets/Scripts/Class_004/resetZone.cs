using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetZone : MonoBehaviour
{
    public Ball_Movement b;
    public Ball_Shooter bs;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == b.gameObject)
        {
            bs.ResetBall();
        }
    }
}
