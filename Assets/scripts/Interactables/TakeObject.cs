using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TakeObject : MonoBehaviour
{
    public Renderer rend;
    public static bool takenState;
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        if(gameObject!=null)
        {
            if (GameManager.myInstance.interObj.conditionMet)
            {
                rend.enabled = false;
                takenState = true;
            }
            else
            {
                Debug.Log("Not Yet");
            }
        }  
    }
}
