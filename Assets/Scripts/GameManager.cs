using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager> {
	[HideInInspector]
	public AudioClip selectedAudio;
    protected override void Init()
    {

    }
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		DontDestroyOnLoad(gameObject);
	}
}
