using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageViewer : Interactable
{
    public Sprite picture;

    public int pass = 0; 
    public override void Interact()
    {
        if(pass == 0)
        {
            GameManager.myInstance.ivCanvas.Activate(picture);
        }
        else if (pass == 1)
        {
            GameManager.myInstance.ivCanvas.ActivateScene();
        }
    }
}
