using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Machine : MonoBehaviour {

    private int currentState;
    private int count;
    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject sphere3;

    // Use this for initialization
    void Start () {
        Debug.Log("start state machine");
        currentState = 0;
        count = 0;
        execute(currentState);
        sphere1.SetActive(false);
        sphere2.SetActive(false);
        sphere3.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) execute(currentState);
	}

    void execute(int state) {
        switch(state)
        {
            case 0:
                Debug.Log("stato " + currentState);
                count++;
                break;
            case 1:
                Debug.Log("stato " + currentState);
                if (count==0)
                {
                    sphere1.SetActive(true);
                }
                else if (count==1)
                {
                    sphere2.SetActive(true);
                }
                else if (count==2)
                {
                    sphere3.SetActive(true);
                }
                count++;
                break;
            case 2:
                sphere1.SetActive(true);
                sphere2.SetActive(true);
                sphere3.SetActive(true);
                Debug.Log("stato " + currentState);
                break;
            default:
                break;

            
           
        }
        nextState();  

    }

    void nextState()
    {
        int next;
        switch (currentState)
        {
            case 0:
                if (count > 0)
                {
                    next = 1;
                    count = 0;
                    currentState = next;
                }
                break;
            case 1:
                if (count > 3)
                {
                    next = 2;
                    currentState = next;
                }
                else
                {
                    count++;
                }
                break;
            case 2:
                break;
            default:
                break;



        }
    }

    }
