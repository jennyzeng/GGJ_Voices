using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioHelper {
	// private AudioClip[] clips;
	// private AudioSource aud;

	// Use this for initialization
	// void Start () {
	// 	aud = GetComponent<AudioSource>();
	// }
	
	// // Update is called once per frame
	// void Update () {
		
	// }
		
	public static List<AudioClip> divideClip(AudioClip clip, float length, int divides)
	{

		List<AudioClip> clips = new List<AudioClip>();
		int frequency = clip.frequency;
		float timeLength = (length)/ (float) divides;
		int samplesLength = (int)(frequency * timeLength);
		for (int i = 0; i < divides; i++) {
			clips.Add(AudioClip.Create(i+"", samplesLength, 1, frequency, false));
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
		/* Return the sub clip */
	}

	// IEnumerator play(List<AudioClip> clips){
	// 	for (int i = 0; i < clips.Count; i++) {
	// 		aud.clip = clips[i];
	// 		aud.Play ();
	// 		yield return new WaitForSeconds(clips[i].length);
	// 	}
	// }
}
