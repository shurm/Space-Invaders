﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayHighScores : MonoBehaviour
{
    // Start is called before the first frame update
    public HighScoreDirector highScoreDirector;
    public Text scoreAndNamePrefab;
    void Start()
    {
        List<string> names = highScoreDirector.GetHighScoreNames();
        List<int> scores = highScoreDirector.GetHighScores();

        for(int i=0;i<scores.Count;i++)
        {
            Text newText = Instantiate(scoreAndNamePrefab, gameObject.transform);
            newText.text = names[i] + " - " + scores[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Submit")!=0)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
