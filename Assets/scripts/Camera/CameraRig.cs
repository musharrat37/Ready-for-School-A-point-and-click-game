using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRig : MonoBehaviour //put all the camera related activities here
{

    public Transform yAxis;
    public Transform xAxis;
    

    public float moveTime; //rate of animation speed

    public void AlignTo(Transform target)
    {
        Sequence sequence1 = DOTween.Sequence();
        sequence1.Append(yAxis.DOMove(target.position, 0.75f));
        sequence1.Join(yAxis.DORotate(new Vector3(0f,target.rotation.eulerAngles.y,0f), 0.75f));
        sequence1.Join(xAxis.DOLocalRotate(new Vector3(target.rotation.eulerAngles.x, 0f, 0f), 0.75f));
    }
}
