using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARaudioController : SingletonBase<ARaudioController> {

	List<AudioClip> randomList;
	private AudioSource aud;
	private string nextLoadScene="Menu";

	void Start()
	{
		aud = GetComponent<AudioSource> ();
	}

    protected override void Init()
    {
        // randomList = GameManager.Instance.GetDividedList();
    }
	public void ButtonClickRequest()
	{
		if (randomList.Count==0)
		{
			randomList = GameManager.Instance.GetDividedList();
		}
		int idx = Random.Range(0, randomList.Count-1);
		AudioClip clip = randomList[idx];
		aud.clip = clip;
		aud.Play();
		randomList.Remove(clip);
		if (randomList.Count == 0)
		{
			SceneManager.LoadScene(nextLoadScene);
		}
	}

}
