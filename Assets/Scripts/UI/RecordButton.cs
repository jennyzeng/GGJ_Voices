using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RecordButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public float recordMaxLength;
	public Image mask;
	private float startTime;
	private bool isRecordStarted;
	private AudioSource aud;
	private string mic;

	void Start()
	{
		mask.fillAmount=0;
		aud = GetComponent<AudioSource>();
		Application.RequestUserAuthorization (UserAuthorization.Microphone);
		if (Microphone.devices.Length == 0) {
			Debug.LogWarning ("No microphone found to record audio clip sample with.");
			return;
		}
		mic = Microphone.devices [0];
	}
    public void OnPointerDown(PointerEventData eventData)
    {
		Debug.Log("button down");
		StartRecord();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
		Debug.Log("button up");
		EndRecord();
    }


	void StartRecord()
	{
		isRecordStarted = true;
		startTime = Time.time;

		aud.clip = Microphone.Start(mic, false, 10, 44100);


	}
	void EndRecord()
	{
		if (!isRecordStarted) return;
		Microphone.End(mic);
		isRecordStarted = false;


		aud.Play();
		// TODO: save record.....
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (isRecordStarted)
		{
			mask.fillAmount = Mathf.Min((Time.time-startTime)/recordMaxLength, 1);
		}
		if (mask.fillAmount==1)
		{
			EndRecord();
		}
	}

}
