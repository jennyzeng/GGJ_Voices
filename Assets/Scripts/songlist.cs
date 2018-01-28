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
		aud.clip = list[Random.Range(0, list.Length)] as AudioClip;
		// aud.Play ();
		GameManager.Instance.selectedClips=aud.clip;
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
