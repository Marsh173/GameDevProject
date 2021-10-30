using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textscript : MonoBehaviour
{
    public enum Stages { StageZero, StageOne, StageTwo, StageThree, StageFour} //can take specific numbers for enums. i.e. StageZero = 4;
    public Stages myStage = Stages.StageZero;

    private TMP_Text myText;
    public string defaultText = "Sample";

    public string textOne;
    public string textTwo;
    private int textNumber = 0;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        myText.text = defaultText;
    }

    void EnumTextChanger()
    {
        switch (myStage)
        {
            case Stages.StageZero:
                myText.text = myStage.ToString();
                myStage = Stages.StageOne;
                break;

            case Stages.StageOne:
                myText.text = myStage.ToString();
                myStage = Stages.StageTwo;
                break;

            case Stages.StageTwo:
                myText.text = myStage.ToString();
                myStage = Stages.StageThree;
                break;

            case Stages.StageThree:
                myText.text = myStage.ToString();
                myStage = Stages.StageFour;
                break;

            case Stages.StageFour:
                myText.text = myStage.ToString();
                myStage = Stages.StageZero;
                break;
        }

        #region if statement.
        /*
        if(myStage == Stages.StageOne)
        {
            myText.text = myStage.ToString();
            myStage = Stages.StageTwo;
        }
        else if(myStage == Stages.StageTwo)
        {
            myText.text = myStage.ToString();
            myStage = Stages.StageThree;
        }

        else if (myStage == Stages.StageThree)
        {
            myText.text = myStage.ToString();
            myStage = Stages.StageFour;
        }
        else if (myStage == Stages.StageFour)
        {
            myText.text = myStage.ToString();
            myStage = Stages.StageOne;
        }
        */
        #endregion                                                                      
    }

    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
    }
    void textInputChanger()
    {
        if (textNumber == 0)
        {
            myText.text = textOne;
            textNumber = 1;
        }
        else if (textNumber == 1)
        {
            myText.text = textTwo;
            textNumber = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myText.text = "Count" + count;
            count++;
        }
        

        if (Input.GetKeyDown(KeyCode.G))
        {
            //textInputChanger();
            EnumTextChanger();
        }
    }
}
