using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoCanvas : MonoBehaviour {

    // Use this for initialization
    public MovieTexture movie;

    void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        movie.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
