using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StateCheck : MonoBehaviour
{

    void OnMouseDown()
    {
        if (gameObject != null)
        {
            if(TakeObject.takenState)
            {
                this.enabled = true;
                //Invoke(FindSceneObjectsOfType, 2);
            }
            else
            {
                this.enabled = false;
                Debug.Log("Forgetting something?");
            }
        }
    }

}
