using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager> {
	public AudioClip selectedAudio;
    protected override void Init()
    {
		DontDestroyOnLoad(gameObject);
    }
}
