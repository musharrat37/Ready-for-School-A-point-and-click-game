using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{

    public Sprite[] blockFace;
    public Sprite blockBack;

    public GameObject[] blocks;

    public Text scoreText;

    private bool init = false;
    public int score = 0;

    public Text timerText;
    public float timer = 50;//main countdown


    // Update is called once per frame

    void Update()
    {
        if(!init)
        {
            InitializeBlocks();
        }
        if(Input.GetMouseButtonUp(0))
        {
            CheckBlocks();
        }

        TimerCountdown();
    }

    public void InitializeBlocks()
    {
        for(int id = 0; id<2; id++)
        {
            for(int i = 1; i<8; i++)
            {
                bool test = false;
                int choice = 0;
                while(!test)
                {
                    choice = Random.Range(0, blocks.Length);
                    test = !(blocks[choice].GetComponent<Block>().Initialized);
                }
                blocks[choice].GetComponent<Block>().BlockContent = i;
                blocks[choice].GetComponent<Block>().Initialized = true;
            }
        }
        foreach(GameObject b in blocks)
        {
            b.GetComponent<Block>().SetupGraphics();
        }

        if(!init)
        {
            init = true;
        }

    }

    public Sprite GetBlockBack()
    {
        return blockBack;
    }

    public Sprite GetBlockFace(int i)
    {
        return blockFace[i-1];
    }

    public void CheckBlocks()
    {
        List<int> b = new List<int>();

        for (int i = 0; i < blocks.Length ; i++)
        {
            if(blocks[i].GetComponent<Block>().State==1)
            {
                b.Add(i);
            }
        }
        if(b.Count == 2)
        {
            BlockComparison(b);
        }
    }

    public void BlockComparison(List<int> b)
    {
        Block.doNot = true;

        int x = 0;

        if(blocks[b[0]].GetComponent<Block>().BlockContent==blocks[b[1]].GetComponent<Block>().BlockContent)
        {
            x = 2;
            score += 10;
            GameOverManager.overScore = score;
            GameManager.myInstance.puzzleScore = score;
            scoreText.text = "Score: " + score;
            if(score>=70)
            {
                SceneManager.LoadScene("Game Over");
            }
        }
        for(int i = 0; i<b.Count; i++)
        {
            blocks[b[i]].GetComponent<Block>().State = x;
            blocks[b[i]].GetComponent<Block>().FalseCheck();
        }
    }

    public void TimerCountdown()
    {
        if (timer>=0.0f)
        {
            timer -= Time.deltaTime;
            timerText.text = "Timer for Bonus: " + timer.ToString("0.0");
            if(score>=70 && timer>0.0f)
            {
                GameOverManager.overTimer = 20;
            }
        }
        else
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
