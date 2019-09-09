using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDirector : MonoBehaviour
{
    public string highscoreFilePath;
    private int limit = 5;

    private List<int> scores = new List<int>();
    private List<string> names = new List<string>();

    public GameObject DisplayScoresCanvas;
    public GameObject UserInputCanvas;

    public TMP_InputField userInputForNewName;
    public Text newScoreText;
    private int newScore =0; 
    // Start is called before the first frame update
    void Start()
    {
        newScore = PlayerPrefs.GetInt("playerScore");

        highscoreFilePath = Application.dataPath + "/" + highscoreFilePath;
        if (!File.Exists(highscoreFilePath))
        {
            File.Create(highscoreFilePath);
        }
        //Debug.Log(highscoreFilePath);
        IEnumerable<string> fileLines = File.ReadLines(highscoreFilePath);
        
        foreach (string line in fileLines)
        {
            string[] nameAndScore = line.Split(',');
            names.Add(nameAndScore[0]);
            scores.Add(int.Parse(nameAndScore[1]));
        }
        if(newScore<0 || (scores.Count==limit && scores[limit-1]>= newScore))
        {
            UserInputCanvas.SetActive(false);
            DisplayScoresCanvas.SetActive(true);

        }
        else
        {
            newScoreText.text = "Score: "+ newScore;
        }

    }

    private void AddNewHighScore(string newName)
    {
        int i = scores.Count - 1;
        while (i >= 0 && scores[i] < newScore)
        {
            i--;
        }
        if (i + 1 == scores.Count)
        {
            scores.Add(newScore);
            names.Add(newName);
        }
        else
        {
            scores.Insert(i + 1, newScore);
            names.Insert(i + 1, newName);
        }

        if (scores.Count > limit)
        {
            scores.RemoveAt(scores.Count - 1);
            names.RemoveAt(names.Count - 1);
        }
        List<string> newFileLines = new List<string>();
        for(i=0;i<scores.Count;i++)
        {
            newFileLines.Add(names[i] + "," + scores[i]);
        }
        File.WriteAllLines(highscoreFilePath, newFileLines);
       
    }
    public List<string> GetHighScoreNames()
    {
        return names;

    }
    public List<int> GetHighScores()
    {
        return scores;
    }

    public void UpdateAndDisplayScores()
    {
        string userInput = userInputForNewName.text.Trim();

        AddNewHighScore(userInput);

        UserInputCanvas.SetActive(false);

        DisplayScoresCanvas.SetActive(true);

    }
}
