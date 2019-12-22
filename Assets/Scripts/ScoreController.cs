using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int currentScore = 0;
    public Text scoreText;

    // Update is called once per frame
    public void UpdateScore(int pointsEarned)
    {
        currentScore += pointsEarned;
        scoreText.text = currentScore+"";
    }

}
