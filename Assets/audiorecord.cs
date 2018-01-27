using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiorecord : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.RequestUserAuthorization (UserAuthorization.Microphone);
		AudioSource aud = GetComponent<AudioSource>();
		if (Microphone.devices.Length == 0) {
			Debug.LogWarning ("No microphone found to record audio clip sample with.");
			return;
		}
		string mic = Microphone.devices [0];
		aud.clip = Microphone.Start(mic, true, 10, 44100);
		aud.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
