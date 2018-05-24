using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using System;

public class RecipeWindow : MonoBehaviour, IInputClickHandler {
    //string json_file_name = null;
    int nb = 0;

	// Use this for initialization
	void Start () {
		
	}

   /* public void setJsonFileName(string json_file)
    {
        this.json_file_name = json_file;
    }*/
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setInfo(string recipe_title, int pos) {
        Text text = this.transform.GetChild(1).GetComponent<Text>();
        text.text = recipe_title;
        nb = pos;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
         
        print("windowisclicked");
        MenuManager menu_manager = GameObject.Find("Menu Manager").GetComponent<MenuManager>();
        //int json_index = menu_manager.getJsonFilePathListNb(json_file_name);
        menu_manager.updateJsonReaderAndLoadScene(nb);
    
        //throw new NotImplementedException();
    }
}
