using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setInfo(string recipe_title) {
        Text text = this.transform.GetChild(1).GetComponent<Text>();
        text.text = recipe_title;
    }
}
