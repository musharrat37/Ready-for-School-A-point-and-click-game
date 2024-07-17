using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationBus : MonoBehaviour
{
    [SerializeField]
    private Transform closedTransform2;

    [SerializeField]
    private Vector3 openTransform2;

    [SerializeField]
    private float animationTime2 = 1.5f;

    void Start()
    {
        closedTransform2 = gameObject.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (GameManager.myInstance.interObj.conditionMet)
        {
            closedTransform2.DOLocalMove(new Vector3(openTransform2.x, openTransform2.y, openTransform2.z), animationTime2);
            Debug.Log("Its 7 am The bus is here");
        }
    }

}
