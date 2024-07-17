using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Node {

    public Location loc;

    Interactable interactBy;

    void Start()
    {
        interactBy = GetComponent<Interactable>(); // if component is interactable it will put the reference inside interact.
                                                //If it doesn't it'll be null 
    }

    public override void UponArrival()
    {
        if (interactBy !=null && interactBy.enabled)
        {
            interactBy.Interact();
            return;
        }

        base.UponArrival();

        //make this object interactable
        if(interactBy != null)
        {
            collider1.enabled = true;
            interactBy.enabled = true;
        }
    }

    public override void Leave()
    {
        base.Leave();

        if(interactBy != null)
        {
            interactBy.enabled = false;
        }
    }
}
