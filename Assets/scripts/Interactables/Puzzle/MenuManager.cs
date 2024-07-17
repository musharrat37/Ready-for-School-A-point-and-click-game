using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void triggerMenuBehaviour(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("Puzzle");
                break;
            case (1):
                SceneManager.LoadScene("Child Bedroom");
                break;
        }
    }
}
