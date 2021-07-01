using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
public class ScoreManger : MonoBehaviour
{
    public static ScoreManger instance;
    public TextMeshProUGUI text;
    int score; 
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this; 
        }
    }

    // Update is called once per frame
    public void ChangeScore(int itemValue)
    {
        score += itemValue;
        text.text = "X" + score.ToString(); 
    }
}
