using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class006_ManualAnimation : MonoBehaviour
{
    SpriteRenderer spriteRender;

    public List<Sprite> imageList = new List<Sprite>();
    public float speed = 1.0f;
    public float moveSpeed = 1.0f;

    public AnimationCurve animationCurve;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //StartCoroutine(Animate());
        //StartCoroutine(Move());
        StartCoroutine(EvalCurve());
    }

    IEnumerator EvalCurve()
    {
        float t = 0.0f;
        while(t < 1.0f)
        {
            t += Time.deltaTime;
            transform.position = new Vector3(animationCurve.Evaluate(t), 0.0f, 0.0f);
            yield return null;
        }
        yield return null;
    }

    IEnumerator Animate()
    {
        int counter = 0;

        while(true)
        {
            spriteRender.sprite = imageList[counter];
            yield return new WaitForSeconds(speed);
            counter++;

            if(counter > imageList.Count -1)
            {
                counter = 0;
            }
        }

        //never exit the loopp
        Debug.Log("Start Coroutine");
        spriteRender.color = Color.red;

        yield return new WaitForSeconds(2.0f);

        spriteRender.color = Color.black;
        Debug.Log("End Coroutine");
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.position = new Vector3(transform.position.x - (Time.deltaTime * moveSpeed), transform.position.y, transform.position.z);
            yield return null;
            if(transform.position.x < -10.0f)
            {
                transform.position = new Vector3(10.0f, transform.position.y, transform.position.z);
            }
        }
    }

}
