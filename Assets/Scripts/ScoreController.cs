using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int currentScore = 0;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Number").GetComponent<Text>();
    }

    // Update is called once per frame
    public void UpdateScore(int pointsEarned)
    {
        currentScore += pointsEarned;
        scoreText.text = currentScore+"";
    }

}
