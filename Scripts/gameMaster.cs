using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameMaster : MonoBehaviour
{
    //public int points;
    //public Text pointsText;
    public static gameMaster instance;
    public TextMeshProUGUI text;
    public int points;

    void Start()
    {
       if(instance == null)
        {
            instance = this;
        } 
    }

    public void changeScore()
    {
        points++;
        text.text = "Coins: " + points.ToString();
    }

}
