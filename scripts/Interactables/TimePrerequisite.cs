using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Prop))]
public class TimePrerequisite : InteractObject
{
    public InteractObject inter;

    void Start()
    {
        inter = gameObject.GetComponent<InteractObject>();
    }
    // Update is called once per frame
    public override void Interact()
    {
        if (!TakeObject.takenState)
        {
            //inter.enabled = false;
            Debug.Log("Forgetting Something??");
        }
        else
        {
            //inter.enabled = true;
            base.Interact();
            Debug.Log("Off to School!");
            SceneManager.LoadScene("ExitScene",LoadSceneMode.Additive);
        }
    }
}
