using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Prop))]
public abstract class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false; // when game first starts no interactable function of prop will be active
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + name);
    }

}
