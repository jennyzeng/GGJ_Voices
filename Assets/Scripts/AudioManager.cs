using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : SingletonBase<AudioManager> {
	AudioSource aud;
    protected override void Init()
    {
        // throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		aud = GetComponent<AudioSource>();
	}
	
	public void RequestPlayClip(AudioClip clip)
	{
		if (aud.isPlaying) aud.Stop();
		aud.clip = clip;
		aud.Play();
	}
	
	public void RequestStopClip()
	{
		if (aud.isPlaying) aud.Stop();
	}
}
