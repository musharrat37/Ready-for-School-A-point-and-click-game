using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PuzzleManager puzzle;

    public Text scoreText;
    public static int overScore;

    public static double overTimer;

    public int timeBonus = 5 ;
    public int totalScore;
    public static bool playState = false;


    void Update()
    {
        puzzle = gameObject.GetComponent<PuzzleManager>();
        
        scoreText.text = "SCORE: " + GetTotalScore();
        playState = true;
        GameManager.myInstance.puzzleScore = GetTotalScore();
    }

    public int GetTotalScore()
    {
        timeBonus *= (int)overTimer;
        return (overScore + timeBonus);
    }
}
