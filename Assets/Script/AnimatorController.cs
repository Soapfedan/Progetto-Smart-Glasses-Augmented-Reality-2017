using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    public Animator anim;
    public GameObject[] gameobjs = new GameObject[5];
    private static string element;

	// Use this for initialization
	void Start () {
        disableObjects();
        anim = GetComponent<Animator>();
       
	}
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKeyDown(KeyCode.A))
        {
            disableObjects();
            gameobjs[0].SetActive(true);
            anim.Play("pezzo1", -1, 0f);
            Debug.Log(gameobjs[0].name);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            disableObjects();
            gameobjs[1].SetActive(true);
            anim.Play("pezzo2", -1, 0f);
            Debug.Log(gameobjs[1].name);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            disableObjects();
            gameobjs[2].SetActive(true);
            anim.Play("pezzo3", -1, 0f);
            Debug.Log(gameobjs[2].name);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            disableObjects();
            gameobjs[3].SetActive(true);
            anim.Play("pezzo4", -1, 0f);
            Debug.Log(gameobjs[3].name);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            disableObjects();
            gameobjs[4].SetActive(true);
            anim.Play("pezzo5", -1, 0f);
            Debug.Log(gameobjs[4].name);
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
