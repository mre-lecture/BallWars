using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSyncManager : MonoBehaviour
{

    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;

    public static PlayerSyncManager Instance;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject getHead()
    {
        return head;
    }

    public GameObject getLeftHand()
    {
        return leftHand;
    }

    public GameObject getRightHand()
    {
        return rightHand;
    }
}
