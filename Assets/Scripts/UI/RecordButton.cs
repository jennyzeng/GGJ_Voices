using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RecordButton : MonoBehaviour, IPointerUpHandler{
	public int recordLength;
	public Image mask;
	public GameObject afterRecordingShowUps;
	public GameObject recordingPanelMask;
	private float startTime;
	private bool isRecordStarted;
	private AudioSource aud;
	private string mic;
	private string saveFileName="record"; // only one file for now
	void Start()
	{
		mask.fillAmount=0;
		afterRecordingShowUps.SetActive(false);
		recordingPanelMask.SetActive(false);
		aud = GetComponent<AudioSource>();
		Application.RequestUserAuthorization (UserAuthorization.Microphone);
		if (Microphone.devices.Length == 0) {
			Debug.LogWarning ("No microphone found to record audio clip sample with.");
			return;
		}
		mic = Microphone.devices [0];
	}

    public void OnPointerUp(PointerEventData eventData)
    {
		if (isRecordStarted)return;
		else StartRecord();
    }
	void StartRecord()
	{
		isRecordStarted = true;
		recordingPanelMask.SetActive(true);
		afterRecordingShowUps.SetActive(false);
		startTime = Time.time;
		aud.clip = Microphone.Start(mic, false, recordLength, 44100);
	}
	void EndRecord()
	{
		if (!isRecordStarted) return;
		recordingPanelMask.SetActive(false);
		Microphone.End(mic);
		isRecordStarted = false;
		aud.Play();
		afterRecordingShowUps.SetActive(true);

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
			mask.fillAmount = Mathf.Min((Time.time-startTime)/recordLength, 1);
		}
		if (Microphone.IsRecording(mic)==false)
		{
			EndRecord();
		}
	}
}
