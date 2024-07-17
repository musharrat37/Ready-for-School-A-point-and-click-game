using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractObject : Interactable
{
    public bool conditionMet;

    [SerializeField]
    private Transform closedTransform;

    [SerializeField]
    private Vector3 openTransform, originalTransform;

    [SerializeField]
    private float animationTime = 1.5f;

    [SerializeField]
    private bool isOpen = false;

    [SerializeField]
    private bool fill = false;

    public InteractObject[] fillObjects;

    [SerializeField]
    private bool fillState = false;

    private AudioSource aSource;

    [SerializeField]
    private TransformType transformType;

    private enum TransformType { translation,rotation}


    void Start()
    {
        closedTransform = gameObject.GetComponent<Transform>();
        originalTransform.x = closedTransform.position.x;
        originalTransform.y = closedTransform.position.y;
        originalTransform.z = closedTransform.position.z;
        FillObjectState();

    }

    public override void Interact()
    {
        if(GameOverManager.playState)
        {
            if (!isOpen)
            {
                switch (transformType)
                {
                    case TransformType.translation:
                        closedTransform.DOLocalMove(new Vector3(openTransform.x, openTransform.y, openTransform.z), animationTime);
                        break;
                    case TransformType.rotation:
                        closedTransform.DOLocalRotate(new Vector3(openTransform.x, openTransform.y, openTransform.z), animationTime);
                        break;
                }

                fillState = true;
                isOpen = true;
                if(fill)
                {
                    FillObjectState(isOpen);
                }
            }
            else
            {
                switch (transformType)
                {
                    case TransformType.translation:
                        closedTransform.DOLocalMove(new Vector3(originalTransform.x, originalTransform.y, originalTransform.z), 1.5f);
                        break;
                    case TransformType.rotation:
                        closedTransform.DOLocalRotate(new Vector3(0f, 0f, 0f), 1.5f);
                        break;
                }
                isOpen = !isOpen;
                fillState = false;
            }
            if (StateCheck())
            {
                GameManager.myInstance.interObj.conditionMet = true;
            }
        }
        else
        {
            Debug.Log("Puzzle not completed yet");
        }
    }

    public void FillObjectState(bool activate=false)
    {
        for(int i = 0; i<fillObjects.Length; i++)
        {
            fillObjects[i].enabled = activate;
        }
    }

    public bool StateCheck()
    {
        int stateCount = 0;
        for (int i = 0; i < fillObjects.Length; i++)
        {
            if(fillObjects[i].fillState)
            {
                stateCount++;
            }
        }
        if(stateCount >= fillObjects.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
