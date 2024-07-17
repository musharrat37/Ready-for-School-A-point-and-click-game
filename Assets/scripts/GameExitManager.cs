using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameExitManager : MonoBehaviour
{

    public Text scoreText;
    public int score;
    void Start()
    {
        score = GameOverManager.overScore;
    }
    


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Overall Score: " + score;
    }

    public void TriggerExitBehaviour()
    {
        Application.Quit();
    }
}
