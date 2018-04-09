using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class RecipeLeftArrow : MonoBehaviour {
    public void OnInputClicked(InputClickedEventData eventData)
    {
        //print("oninputcliked left");
       GameObject.Find("RecipeManager").GetComponent<RecipeManager>().prevStep();

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
