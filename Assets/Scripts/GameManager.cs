using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager> {
	// [HideInInspector]
	public AudioClip selectedClips;
	private List<AudioClip> dividedClips;
	public float audioLength;
	public int numDivides;
	List<AudioClip> randomList;
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

	public List<AudioClip> GetDividedList()
	{
		if (dividedClips==null || dividedClips.Count==0)
		{
			dividedClips = DivideClip(selectedClips, numDivides);
		}
		return dividedClips;
	}
	List<AudioClip> DivideClip(AudioClip clip, int divides)
	{
		List<AudioClip> clips = new List<AudioClip>();
		int frequency = clip.frequency;
		float timeLength = clip.length/ (float) divides;
        Debug.Log(timeLength);
		int samplesLength = (int)(frequency * timeLength);
		for (int i = 0; i < divides; i++) {
			clips.Add(AudioClip.Create(i+"", samplesLength, clip.channels, frequency, false));
			// clips[i] = AudioClip.Create(i+"", samplesLength, 1, frequency, false);
		}

		/* Create a temporary buffer for the samples */
		float[] data = new float[samplesLength];
		/* Get the data from the original clip */
		/* Transfer the data to the new clip */
		for (int i = 0; i < divides; i++) {
			clip.GetData (data, (int)(frequency * i * timeLength));
			clips[i].SetData(data, 0);
		}
		return clips;
	}
}
