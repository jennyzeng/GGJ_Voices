using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class songlist : MonoBehaviour {
	private AudioSource aud;
	private AudioClip[] list;

	public void PlayMusic()
	{
		aud.clip = list [Random.Range(0, list.Length)];
		aud.Play ();
	}
	// Use this for initialization
	void Start () {
		
		DirectoryInfo dir = new DirectoryInfo ("Assets/Resources/music");
		FileInfo[] fileInfo = dir.GetFiles("*.*", SearchOption.AllDirectories);
		int count = 0;
		foreach (FileInfo file in fileInfo) {
			// file extension check
			if (file.Extension == ".aif") {
					count++;
			}
			// etc.
		}
		list = new AudioClip[count];
		string[] names = new string[count];
		int i = 0;
		foreach (FileInfo file in fileInfo) {
			// file extension check
			if (file.Extension == ".aif") {
				names[i] = Path.GetFileNameWithoutExtension(file.FullName);
				list[i] = Resources.Load("music/"+ names[i]) as AudioClip;
				i++;
			}
			// etc.
		}

		aud = GetComponent<AudioSource> ();

		/*

		string path = EditorUtility.OpenFilePanel("Overwrite with wav", "", "aif");
		if (path.Length != 0)
		{
			AudioClip ad = Resources.Load(path) as AudioClip;
			aud = GetComponent<AudioSource> ();
			aud.clip = ad;
			GetComponent<AudioSource>().Play ();
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator play(AudioClip[] clips){
		for (int i = 0; i < clips.Length; i++) {
			aud.clip = clips[i];
			aud.Play ();
			yield return new WaitForSeconds(clips[i].length);
		}
	}
}
