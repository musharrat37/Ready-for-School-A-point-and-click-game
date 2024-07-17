using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager myInstance;

    public int puzzleScore;

    public InteractObject interObj;

    public IVCanvas ivCanvas;

    public Node startingNode;

    [HideInInspector]
    public Node currentNode;

    public CameraRig rig1;

    void Awake()
    {
        myInstance = this; //singleton??
        ivCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
       startingNode.UponArrival();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            if(ivCanvas.gameObject.activeInHierarchy)
            {
                ivCanvas.Close();
                return;
            }
            currentNode.GetComponent<Prop>().loc.UponArrival();
        }
        else if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Location>() != null)
        {
            startingNode.UponArrival();
        }
        
    }
}
