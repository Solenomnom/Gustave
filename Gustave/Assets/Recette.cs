using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recette : MonoBehaviour {

    // Use this for initialization
    public Ingredient[] ingredients;
    public Step[] steps;
    public int progress;
    public Ustensile[] ustensiles;
  
    void Start () {
        progress = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
