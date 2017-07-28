using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    public Animator anim;
    private int currentState=0;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {            
            anim.Play("pezzo5", -1, 0f);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.Play("pezzo4", -1, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.Play("pezzo3", -1, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.Play("pezzo2", -1, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.Play("pezzo1", -1, 0f);
        }
        


    }
}
