using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{
    bool musicPlaying = true;

	void Start () 
    {
        if (MenuItem.music)
            audio.Play();
        else
            musicPlaying = false;
	}

	void Update () 
    {
        if (MenuItem.music && !musicPlaying)
        {
            audio.Play();
            musicPlaying = true;
        }
        else if (!MenuItem.music && musicPlaying)
        {
            audio.Stop();
            musicPlaying = false;
        }
	}
}
