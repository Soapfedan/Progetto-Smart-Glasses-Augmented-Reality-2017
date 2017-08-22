using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour {

    private string animationName;
    private GameObject currentTarget;
    private GameObject nextTarget;
    private string phaseText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Phase(string anim,GameObject curr,GameObject next,string text)
    {
        animationName = anim;
        currentTarget = curr;
        nextTarget = next;
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
}
