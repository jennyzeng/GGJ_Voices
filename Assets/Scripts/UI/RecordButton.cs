using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RecordButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public int recordMaxLength;
	public int recordMinLength;
	public Image mask;
	public GameObject afterRecordingShowUps;
	private float startTime;
	private bool isRecordStarted;
	private AudioSource aud;
	private string mic;
	private string saveFileName="record"; // only one file for now
	void Start()
	{
		mask.fillAmount=0;
		afterRecordingShowUps.SetActive(false);
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
		StartRecord();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
		EndRecord();
    }


	void StartRecord()
	{
		isRecordStarted = true;
		startTime = Time.time;
		aud.clip = Microphone.Start(mic, false, recordMaxLength, 44100);
	}
	void EndRecord()
	{
		if (!isRecordStarted) return;
		Microphone.End(mic);
		isRecordStarted = false;
		if (Time.time-startTime < recordMinLength) mask.fillAmount=0;
		else
		{
			aud.Play();
			afterRecordingShowUps.SetActive(true);
		}
		
	}

	public void SubmitRecord()
	{
		// save and submit record
		SavWav.Save(saveFileName, aud.clip);
	}

	public void PlayRecord()
	{
		// play the record again
		aud.Play();
	}

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
