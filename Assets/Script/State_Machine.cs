using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Machine : MonoBehaviour {

    private static Phase[] phaseList;
    private static bool currentFound, nextFound, singleFound, //flag
        subStateTerminated; 
    private const string OBJECT_FOUND = "OBJECT FOUND", OBJECT_NOT_FOUND = "OBJECT NOT FOUND";
    public GameObject[] multipleObjectArray = new GameObject[10];  //global target -- single object
    private static int phaseNum, //current phase number
         subStateNum; //the number of the substate. A phase is a collection of substates.

    // Use this for initialization
    void Start () {
        Debug.Log("start state machine");

        phaseList = new Phase[5];//initialize the phase list
        for(int i = 0; i < 5; i++)
        {
            phaseList[i] = new Phase("",                             //animation name
                                    multipleObjectArray[2* i],       //current target
                                    multipleObjectArray[2 * i + 2],  //next target
                                    multipleObjectArray[2 * i + 1],  //single object
                                    "");                             //UI text
        }
        phaseNum = 0;
        subStateNum = 0;
        currentFound = false;
        nextFound = false;
        singleFound = false;
        subStateTerminated = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKeyDown(KeyCode.Space)&& subStateTerminated)
		execute(subStateNum);

        
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

    public static void nextState() //metodo che reinizializza tutti i parametri per il substate successivo
    {
        currentFound = false;
        nextFound = false;
        singleFound = false;
        Vuforia.DefaultTrackableEventHandler.setObjectFound(false);
        subStateTerminated = true;
        subStateNum = (subStateNum++) % 3;

    }

    public static Phase[] getPhaseList()
    {
        return phaseList;
    }

    public static int getSubStateNumber()
    {
        return subStateNum;
    }
   
    public static void setCurrentTargetFlag(bool a)
    {
        currentFound = a;
    }

    public static void setNextTargetFlag(bool a)
    {
        nextFound = a;
    }
    public static void setSingleObjectFlag(bool a)
    {
        singleFound = a;
    }

    public static int getPhaseNumber()
    {
        return phaseNum;
    }
}
