using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource), typeof(Button))]
public class OnClickPlayAudio : MonoBehaviour {
	
	AudioSource aud;
	private string nextSceneName;
	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource>();
		// GetComponent<Button>().onClick.AddListener(PlayMusic);
	}

	public void PlayMusic()
	{
		aud.Play();
	}

	public void PlayMusicAndLoadScene(string name)
	{
		nextSceneName = name;
		AudioManager.Instance.RequestStopClip();
		aud.Play();
		TimerManager.Instance.AddTimer(aud.clip.length-1, gameObject, LoadNextScene);
	}

	void LoadNextScene()
	{
		SceneManager.LoadScene(nextSceneName);
	}
}
