using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour {

    public Transform cameraPosition;

    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider collider1;

	void Awake () {
        collider1 = GetComponent<Collider>();
        collider1.enabled = false;
	}
	
    void OnMouseDown()
    {

        UponArrival();

    }
    public virtual void UponArrival()
    {

        //leave existing current node
        if (GameManager.myInstance.currentNode !=null)
        {
            GameManager.myInstance.currentNode.Leave();
        }

        //set current node

        GameManager.myInstance.currentNode = this;

        //move the camera

        GameManager.myInstance.rig1.AlignTo(cameraPosition);

        //Camera.main.transform.position = cameraPosition.position;
       // Camera.main.transform.rotation = cameraPosition.rotation;

        //turn off own collider
        if(collider1 != null)
        {
            collider1.enabled = false;
        }

        //turn on all reachableNode colliders
        SetReachableNodes(true);
    }

    public virtual void Leave()
    {
        //turn off all reachable nodes
        SetReachableNodes(false);
    }

    public void SetReachableNodes(bool set)
    {
        foreach (Node node in reachableNodes)
        {
            if (node.collider1 != null)
            {
                node.collider1.enabled = set;
            }
        }
    }
}
