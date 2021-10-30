using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peg : MonoBehaviour
{
    public Color newColor = Color.white;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PegHitRoutine());
    }   

    IEnumerator PegHitRoutine()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = newColor;
        yield return new WaitForSeconds(0.75f);
        GetComponent<SpriteRenderer>().enabled = false;
    }



}
