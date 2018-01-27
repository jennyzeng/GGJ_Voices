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
	public Button record;

	void Start()
	{
		mask.fillAmount=0;
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
		// TODO: start record...
	}
	void EndRecord()
	{
		if (!isRecordStarted) return;
		isRecordStarted = false;
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
