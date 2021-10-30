using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleClickCircle : MonoBehaviour
{
    SpriteRenderer spriteRender;
    public Color colorOne = Color.yellow;
    public Color colorTwo = Color.cyan;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
 
    public void changeColor(int n)
    {
        if(n == 0)
        {
            spriteRender.color = colorTwo;
        }
        else if (n == 1)
        {
            spriteRender.color = colorOne;
        }
        
    }


}
