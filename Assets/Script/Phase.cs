using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase {

    
    private GameObject currentTarget;
    private GameObject nextTarget;
    private GameObject singleObjectTarget;
    private string phaseText;


    public Phase(GameObject curr,GameObject next,GameObject singleObj)
    {
        
        currentTarget = curr;
        nextTarget = next;
        singleObjectTarget = singleObj;        
    }


    public GameObject getCurrTarget()
    {
        return currentTarget;
    }

    public GameObject getNextTarget()
    {
        return nextTarget;
    }

    public GameObject getSingleObject()
    {
        return singleObjectTarget;
    }
}
