using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase {

    private string animationName;
    private GameObject currentTarget;
    private GameObject nextTarget;
    private GameObject singleObjectTarget;
    private string phaseText;


    public Phase(string anim,GameObject curr,GameObject next,GameObject singleObj, string text)
    {
        animationName = anim;
        currentTarget = curr;
        nextTarget = next;
        singleObjectTarget = singleObj;
        phaseText = text;
    }

    public string getAnimName()
    {
        return animationName;
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
