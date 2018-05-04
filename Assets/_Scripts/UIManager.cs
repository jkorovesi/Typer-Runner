using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreUI;
    public Text livesUI;

    private int score = 0;
    public int lives = 3;

    public void ScoreUpdate()
    {
        score++;

    }

    public void LivesUpdate()
    {
        lives--;
        if(lives <= 0)
        {
            livesUI.text = "Lives: 0";
        }

    }

	// Update is called once per frame
	void Update () {
        scoreUI.text = "Score: " + score;
        livesUI.text = "Lives: " + lives;
	}
}
