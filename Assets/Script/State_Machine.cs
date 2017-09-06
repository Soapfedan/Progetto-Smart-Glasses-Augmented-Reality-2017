using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class State_Machine : MonoBehaviour {

    private static Phase[] phaseList;
    private static Timer atimer,stepTimer,uiTimer;
    private static bool currentFound, nextFound, singleFound, //flag
        subStateTerminated;
    private const int timerInterval = 20000,stepTimerInterval = 3000,uiTimerInterval = 5000;
    public GameObject UIPanel,responsePanel; //Ui panel where the state machine display a message.
    private int touch;
    public static Text objectText,responseText;
    private static string[] uiText = {""};
    private const string OBJECT_FOUND = "OBJECT FOUND", OBJECT_NOT_FOUND = "OBJECT NOT FOUND";
    public GameObject[] multipleObjectArray = new GameObject[10];  //global target -- single object
    private static int phaseNum, //current phase number
         subStateNum; //the number of the substate. A phase is a collection of substates.
    

    // Use this for initialization
    void Start () {
        Debug.Log("start state machine");

        phaseList = new Phase[3];//initialize the phase list
        for(int i = 0; i < 3; i++)
        {
            phaseList[i] = new Phase(multipleObjectArray[2* i],       //current target
                                    multipleObjectArray[2 * i + 2],  //next target
                                    multipleObjectArray[2 * i + 1]  //single object
                                    );                             
        }
        phaseNum = 0;
        subStateNum = 0;
        currentFound = false;
        nextFound = false;
        singleFound = false;
        subStateTerminated = true;
        responsePanel.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (subStateTerminated && subStateNum == 1) //
        {
            responsePanel.SetActive(true);
            responseText.text = "Ok oggetto rilevato";
            stepTimer = new Timer();
            stepTimer.Elapsed += new ElapsedEventHandler(OnStepTimedEvent);
            stepTimer.Interval = stepTimerInterval; //ms
            stepTimer.Enabled = true;
            stepTimer.Start();            
        }else if(Input.touchCount > 0 && subStateNum == 0 && subStateTerminated)
        {
            Vuforia.DefaultTrackableEventHandler.setObjectFound(false);
            execute(subStateNum);
        }
        */
        
	}
    
    private void execute(int state) {
        subStateTerminated = false;
        Debug.Log("Siamo nella fase " + phaseNum);
        switch(subStateNum)
        {
            case 0: //Stato in cui si deve inquadrare il target iniziale
                Debug.Log("stato " + subStateNum);
                Debug.Log("Inquadra la scena per iniziare");
                objectText.text = "Inquadra l'oggetto di partenza";
                atimer = new Timer();
                atimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                atimer.Interval = timerInterval; //ms
                atimer.Enabled = true;
                atimer.Start();
                break;
            /*case 1: //stato in cui deve inquadarare il pezzo singolo
                Debug.Log("stato " + subStateNum);
                Debug.Log("inquadra l'oggetto singolo");
                atimer = new Timer();
                atimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                atimer.Interval = timerInterval; //ms
                atimer.Enabled = true;
                atimer.Start();
                break;*/
                
            case 1: //stato in cui deve inquadrare il target finale
            
                Debug.Log("stato " + subStateNum);
                Debug.Log("Inquadra l'oggeto finale");
                objectText.text = "Inquadra il target finale";
                AnimatorController.playAnim = true;
                stepTimer.Stop();
                atimer = new Timer();
                atimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                atimer.Interval = timerInterval; //ms
                atimer.Enabled = true;
                atimer.Start();
                break;

            default:
                break;

            
           
        }
        Vuforia.DefaultTrackableEventHandler.setObjectFound(false);


    }

    public static void nextState() //metodo che reinizializza tutti i parametri per il substate successivo
    {
        //currentFound = false;        
        nextFound = false;
        singleFound = false;        
        subStateTerminated = true;
        atimer.Stop();
        subStateNum = (subStateNum++) % 2;
        if (subStateNum == 0) {
            phaseNum++;
        }        
        Debug.Log("Cambiamento di stato a " + subStateNum);

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

    // Specify what you want to happen when the Elapsed event is raised.
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Debug.Log("Timer scaduto!");
        switch (subStateNum)
        {            
            case 0:
                Debug.Log("Non riesco ad inquadrare il target di partenza!");
                responsePanel.SetActive(true);
                responseText.text = "Non ho trovato l'oggetto riprova";               
                uiTimer = new Timer();
                uiTimer.Elapsed += new ElapsedEventHandler(OnUITimedEvent);
                uiTimer.Interval = uiTimerInterval; //ms
                uiTimer.Enabled = true;
                uiTimer.Start();
                execute(subStateNum);
                break;
            case 1:
                Debug.Log("Non riesco ad inquadrare il target finale!");
                if (!singleFound) //non è stato trovato nulla
                {
                    responsePanel.SetActive(true);
                    responseText.text = "Non ho trovato l'oggetto riprova";
                }
                else //è stato trovato solo l'oggetto singolo
                {
                    responsePanel.SetActive(true);
                    responseText.text = "Hai montato male il pezzo";
                }
                uiTimer = new Timer();
                uiTimer.Elapsed += new ElapsedEventHandler(OnUITimedEvent);
                uiTimer.Interval = uiTimerInterval; //ms
                uiTimer.Enabled = true;
                uiTimer.Start();

                break;
            default:
                break;
        }
    }

    private void OnStepTimedEvent(object source, ElapsedEventArgs e) {
        responsePanel.SetActive(false);
        execute(subStateNum);
    }

    private void OnUITimedEvent(object source, ElapsedEventArgs e)
    {
        responsePanel.SetActive(false);
    }
}
