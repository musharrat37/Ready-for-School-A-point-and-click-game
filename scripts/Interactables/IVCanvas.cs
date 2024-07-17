using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IVCanvas : MonoBehaviour
{
    public Image imageHolder;
    public void Activate(Sprite picture)
    {
        GameManager.myInstance.currentNode.SetReachableNodes(false);
        GameManager.myInstance.currentNode.collider1.enabled = false;
        gameObject.SetActive(true);
        imageHolder.sprite = picture;
    }

    public void ActivateScene()
    {
        if(!GameOverManager.playState)
        {
            GameManager.myInstance.currentNode.SetReachableNodes(false);
            GameManager.myInstance.currentNode.collider1.enabled = false;
            gameObject.SetActive(true);
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
        else
        {
            Debug.Log("puzzle completed");
        }
        
    }
    public void Close()
    {
        GameManager.myInstance.currentNode.SetReachableNodes(true);
        GameManager.myInstance.currentNode.collider1.enabled = true;
        gameObject.SetActive(false);
        imageHolder.sprite = null;
    }
}
