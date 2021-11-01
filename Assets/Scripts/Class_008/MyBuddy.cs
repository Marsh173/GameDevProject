using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBuddy : MonoBehaviour
{
    public float speed = 1.0f;
    MyGridSystem gridSystem;

    Vector2 nextLocation = new Vector2();

    SpriteRenderer spriteRender;

    public bool isActive;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    //start is called before the firist fram update
    //seting the grid system & sietting isACTIVE = TRUE
    private void Start()
    {
        gridSystem = GameObject.FindGameObjectWithTag("GridSystem").GetComponent<MyGridSystem>();
        isActive = true;
        StartCoroutine(MoveToLocation());

    }

    //while isActive, move the gameobject to a ne wlocation, wait 1 sec
    //them move it to a new locaition that it gets from the grid system
    IEnumerator MoveToLocation()
    {
        while (isActive)
        {
            float t = 0.0f;
            nextLocation = gridSystem.GetRandomLocation();
            Vector2 startLocation = transform.position;
            
            while(t < 1.0f)
            {
                t += Time.deltaTime * speed;
                transform.position = Vector2.Lerp(startLocation, nextLocation, t);
                
            }
            yield return new WaitForSeconds(0.1f);
        }
        
    }


}
