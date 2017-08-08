using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    public static int highScore = 0;
    private Text myText;

    private void Start()
    {
        myText = GetComponent<Text>();
        Reset();
    }

    public void UpdateScore(int points)
    {
        score += points;
        if (score > highScore) highScore = score;
        myText.text = score.ToString();
    }

    public static void Reset()
    {
        score = 0;
    }

}
