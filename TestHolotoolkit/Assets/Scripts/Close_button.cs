using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Close_button : MonoBehaviour, IInputClickHandler
{
    public void OnInputClicked(InputClickedEventData eventData)
    {
        GameObject.Find("Error Popup").SetActive(false);
        GameObject.Find("Missing Email").SetActive(false);
        GameObject.Find("Missing Username").SetActive(false);
        GameObject.Find("Missing Password").SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
