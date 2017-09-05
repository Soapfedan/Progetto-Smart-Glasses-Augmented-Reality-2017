using UnityEngine;
using System.Timers;
using UnityEngine.UI;

public class State_Machine : MonoBehaviour {

    private static Phase[] phaseList;
    private static Timer atimer;
    private static bool currentFound, nextFound, singleFound, //flag
        subStateTerminated;
    private const int timerInterval = 20000;
    public GameObject UIPanel,responsePanel; //Ui panel where the state machine display a message.
    private int touch;
    public Text objectText,responseText;
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

        /*if(Input.touchCount >0 && subStateTerminated)
		execute(subStateNum);
        */
        if (Input.touchCount > 0)
        {
            switch (touch)
            {
                case 0:
                    responsePanel.SetActive(true);
                    responseText.text = OBJECT_FOUND;
                    break;

                case 1:
                    responsePanel.SetActive(false);
                    break;

                case 2:
                    responsePanel.SetActive(true);
                    responseText.text = OBJECT_NOT_FOUND;
                    break;
                default:
                    break;
            }
            touch++;
            if (touch == 3) { touch = 0; }
            
        }
        

        
	}
    
    void execute(int state) {
        subStateTerminated = false;
        Debug.Log("Siamo nella fase " + phaseNum);
        switch(state)
        {
            case 0: //Stato in cui si deve inquadrare il target iniziale
                Debug.Log("stato " + subStateNum);
                Debug.Log("Inquadra la scena per iniziare");               
                break;
            case 1: //stato in cui deve inquadarare il pezzo singolo
                Debug.Log("stato " + subStateNum);
                Debug.Log("inquadra l'oggetto singolo");
                atimer = new Timer();
                atimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                atimer.Interval = timerInterval; //ms
                atimer.Enabled = true;
                atimer.Start();
                break;

            case 2: //stato in cui deve inquadrare il target finale
            
                Debug.Log("stato " + subStateNum);
                Debug.Log("Premi spazio per andare alla prossima fase");
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
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Debug.Log("Timer scaduto!");
        switch (subStateNum)
        {            
            case 1:
                Debug.Log("Non riesco ad inquadrare l'oggetto singolo!");
                break;
            case 2:
                Debug.Log("Non riesco ad inquadrare il target finale!");
                break;
            default:
                break;
        }
    }
}
