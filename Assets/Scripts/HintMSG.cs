using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class HintMSG : MonoBehaviour
{
    private bool wasAnamoly = false;
    private string anamolyData;


    public TextMeshPro myTextElement;

    private static HintMSG instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this new one
            Destroy(gameObject);
        }
    }


    public void anamolyStatusTrue(string anamolyName)
    {
        anamolyData = anamolyName;
    }

    public void ChangeText()     // This Method Tells You Anamoly Type
    {
     
        if (anamolyData != null)
            {
                myTextElement.text = "Wrong Choice of Elevator. \nThere was an anamoly. \nThe anamoly was: " + anamolyData;
            myTextElement.color = Color.red;
            }        
    }

    public void resetText()
    {
        myTextElement.text = "";
    }

    public void noAnamolyChangeText()
    {
        myTextElement.text = "Wrong Choice of Elevator. \nThere was no anamoly";
        myTextElement.color = Color.red;
    }



}
