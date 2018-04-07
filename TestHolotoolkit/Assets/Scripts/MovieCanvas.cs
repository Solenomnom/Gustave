using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieCanvas : MonoBehaviour {

    // Use this for initialization
    private MovieTexture movie_texture;

    void Start () {
        this.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = movie_texture as MovieTexture;
    }

    public void Play()
    {
        movie_texture.Play();
    }

    public void Pause()
    {
        if (movie_texture.isPlaying)
            movie_texture.Pause();
    } 

    public void Restart()
    {
        movie_texture.Stop();
    }

    public bool isPlaying() { return movie_texture.isPlaying; }

    public void setMovieTexture(MovieTexture movie)
    {
        movie_texture = movie;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
