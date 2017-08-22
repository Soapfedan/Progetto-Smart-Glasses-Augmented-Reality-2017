using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Machine : MonoBehaviour {

    private int currentState, phase;
    public GameObject target0,target1;
    public GameObject pezzo;
    private Phase[] states;
    private static Dictionary<string, bool> targets;

    // Use this for initialization
    void Start () {
        Debug.Log("start state machine");
        
        states[0] = new Phase("pezzo5", target0, target1, "");
        currentState = 0;
        phase = 0;
        target0.SetActive(false);
        target1.SetActive(false);
        pezzo.SetActive(false);
        targets.Add("fire", false);
        targets.Add("bbank", false);

    }
	
	// Update is called once per frame
	void Update () {
		execute(currentState);
	}

    void execute(int state) {
        switch(state)
        {
            case 0: //Stato in cui si deve inquadrare il primo pezzo per iniziare
                Debug.Log("stato " + currentState);
                Debug.Log("Inquadra la scena per iniziare");
                if (Input.GetKeyDown(KeyCode.S))
                {
                    states[phase].getCurrTarget().SetActive(true);
                    currentState++;                  
                }
                break;
            case 1: //se l'utente guarda il pezzo gli viene mostrata l'animazione
                Debug.Log("stato " + currentState);
                Debug.Log("fase di ricerca");
                if (targets["fire"].Equals(true))
                {
                    pezzo.SetActive(true);
                    AnimatorController.setBool(true);
                    AnimatorController.setElement(states[phase].getAnimName());
                    states[phase].getNextTarget().SetActive(true);
                    if (targets["bbank"].Equals(true))
                    {
                        currentState++;
                    }
                }
                else
                {
                    pezzo.SetActive(false);
                    AnimatorController.setBool(false);
                    Debug.Log("Inquadra la scena");

                }
                
                break;
            case 2:
            
                Debug.Log("stato " + currentState);
                Debug.Log("Premi spazio per andare alla prossima fase");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentState = 0;
                }
                    break;
            default:
                break;

            
           
        }
       // nextState();  

    }

    /*void nextState()
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
    }*/

    public static Dictionary<string,bool> getTargets()
    {
        return targets;
    }
    }
