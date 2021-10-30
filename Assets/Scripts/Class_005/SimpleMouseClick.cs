using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleMouseClick : MonoBehaviour
{
    Camera mainCam;
    public TMP_Text clickText;
    int points = 0;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Input.mousePosition));
            if (ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                ray.collider.GetComponent<SimpleClickCircle>().changeColor(0);

                points += 1;
                clickText.text = "Clicks: " + points;
            }


        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Input.mousePosition));
            if (ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                ray.collider.GetComponent<SimpleClickCircle>().changeColor(1);

                points -= 1;
                clickText.text = $"Clicks: {points}";
            }
        }

    }

    private void Update()
    {
        ClickCheck();
    }


}
