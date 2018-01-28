using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class songlist : MonoBehaviour {
	private AudioSource aud;
	private Object[] list;
	private string musicPath="music";
	public void PlayMusic()
	{
		AudioClip clip = list[Random.Range(0, list.Length)] as AudioClip;
		GameManager.Instance.selectedClips=clip;
		aud.Play ();
		AudioManager.Instance.RequestStopClip();
		TimerManager.Instance.AddTimer(aud.clip.length-1,this.gameObject, LoadNextScene );
		// SceneManager.LoadScene("AR");
	}

	void LoadNextScene()
	{
		SceneManager.LoadScene("AR");
	}
	// Use this for initialization
	void Start () {
		list = Resources.LoadAll(musicPath, typeof(AudioClip));
		aud = GetComponent<AudioSource> ();
	}

	void OnDestroy()
	{
		Resources.UnloadUnusedAssets();
	}
}
