using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public enum Show {Final, High};
    public Show state;

	// Use this for initialization
	void Start () {
        if(state == Show.High)
        {
            Text myText = GetComponent<Text>();
            myText.text = ScoreKeeper.highScore.ToString();
            ScoreKeeper.Reset();
        }

        if (state == Show.Final)
        {
            Text myText = GetComponent<Text>();
            myText.text = ScoreKeeper.score.ToString();
            ScoreKeeper.Reset();
        }

    }
}

