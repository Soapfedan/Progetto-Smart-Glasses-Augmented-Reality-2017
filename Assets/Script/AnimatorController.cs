using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorController : MonoBehaviour {

    public Animator anim;
    public GameObject[] gameobjs = new GameObject[5];
    private static string element;
    public static bool playAnim;
   

    // Use this for initialization
    void Start() {
        disableObjects();
        anim = GetComponent<Animator>();
        playAnim = false;
    }

    // Update is called once per frame
    void Update() {
        

        if (playAnim) {


            //gli oggetti sono stati inseriti in ordine inverso
            switch (State_Machine.getPhaseNumber())
            {
                case 0:
                    //disableObjects();
                    gameobjs[4].SetActive(true);
                    gameobjs[3].SetActive(true);
                    anim.Play("pezzo4-5", -1, 0f);                    
                    //Debug.Log(gameobjs[4].name);

                    
                    //anim.Play("pezzo4", -1, 0f);
                    //Debug.Log(gameobjs[3].name);
                    break;
                case 1:
                    gameobjs[2].SetActive(true);
                    anim.Play("pezzo3", -1, 0f);
                    //Debug.Log(gameobjs[2].name);
                    break;
                case 2:
                    gameobjs[1].SetActive(true);
                    gameobjs[0].SetActive(true);
                    anim.Play("pezzo1-2", -1, 0f);
                   // Debug.Log(gameobjs[1].name);
                    //.Play("pezzo1", -1, 0f);
                   // Debug.Log(gameobjs[0].name);
                    break;
            }
            //playAnim = false;

        }
        else
        {
           anim.Play("idle", -1, 0f);
        }
        


    }

    public static void setElement(string elem) {
        element = elem;
    }

    private void disableObjects()
    {
        for (int i = 0; i < 5; i++)
        {
            gameobjs[i].SetActive(false);
        }
    }
}
