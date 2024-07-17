using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Block : MonoBehaviour
{
    public static bool doNot = false;

    [SerializeField]
    private int state;
    [SerializeField]
    private int blockContent;
    [SerializeField]
    private bool initialized = false;

    private Sprite blockBack;
    private Sprite blockFace;

    private GameObject manager;

    public int State { get { return state; } set { state = value; } }

    public int BlockContent { get { return blockContent; } set { blockContent = value; } }

    public bool Initialized { get { return initialized; } set { initialized = value; } }

    void Start()
    {
        State = 1;
        manager = GameObject.FindGameObjectWithTag("Manager");

    }

    public void SetupGraphics()
    {
        blockBack = manager.GetComponent<PuzzleManager>().GetBlockBack();
        blockFace = manager.GetComponent<PuzzleManager>().GetBlockFace(BlockContent);

        FlipBlock();
    }

    public void FlipBlock()
    {

        if(State==1)
        {
            State = 0;
        }
        else if(State==0)
        {
            State = 1;
        }

        if ( State == 0 && !doNot)
        {
            GetComponent<Image>().sprite = blockBack;
        }
        else if ( State == 1 && !doNot)
        {
            GetComponent<Image>().sprite = blockFace;
        }
    }

    public void FalseCheck()
    {
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        if(State==0)
        {
            GetComponent<Image>().sprite = blockBack;
        }
        else if(State == 1)
        {
            GetComponent<Image>().sprite = blockFace;
        }
        doNot = false;
    }
}
