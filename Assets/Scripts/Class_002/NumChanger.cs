using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumChanger : MonoBehaviour
{
    public enum CountChanger { StageOne, StageTwo };
    public CountChanger countChanger = CountChanger.StageOne;
    private TMP_Text myText;

    int count = 0;

    void Start()
    {
        myText.text = "Start Counting:";
    }

    void ChangeCount()
    {
        switch (countChanger)
        {
            case CountChanger.StageOne:
                count++;
                countChanger = CountChanger.StageTwo;
                break;

            case CountChanger.StageTwo:
                count--;
                countChanger = CountChanger.StageOne;
                break;
        }


    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCount();
            myText.text = "Count" + count;
            //if (countChanger == CountChanger.StageOne)

        }
    }
}
