using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioClip gunshot;

    public AudioSource Audio;

	// Use this for initialization
	void Start () {
        Audio.clip = gunshot;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGunShot()
    {
        Audio.Play();
    }
}
