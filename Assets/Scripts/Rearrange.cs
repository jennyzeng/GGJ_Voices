using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Rearrange : MonoBehaviour {
	public Canvas theCanvas;
	public int count = 4;
	public Vector3 slotAnchor;
	public Vector3 itemAnchor;
	public float slotInterval = 10f;
	public float itemInterval = 10f;
	public GameObject slotObj;
	public GameObject itemObj;
	public List<AudioClip> clipList = new List<AudioClip>();
	private List<int> realRelation = new List<int>();//user's anwser //deprecated
	private List<int> randRelation = new List<int>();//true anwser
	private List<Vector3> slotPos = new List<Vector3>();
	private List<Vector3> itemPos = new List<Vector3>();
	// Use this for initialization
	void Start () 
	{
		DragCell.OnEnterCell += OnEnterCallBack;
		DragCell.OnLeaveCell += OnLeaveCallBack;
		StartCoroutine(DelayCountCheck());//num check 
		for (int i = 0; i < count; i++)//init
		{
			realRelation.Add(-1);
		}

		GameObject tempObj;
		for (int i = 0; i < count; i++)//create UI elements
		{
			//Debug.Log(randRelation[i]);

			//slotPos.Add(slotAnchor + (i * slotInterval- count*slotInterval/2) * (-Vector3.left));
			//tempObj = Instantiate(slotObj, slotAnchor + (i * slotInterval- count*slotInterval/2) * (-Vector3.left),gameObject.transform.rotation ,theCanvas.transform) as GameObject;
			slotPos.Add(DragCell.cellList[i].transform.position);
		}
		for (int i = 0; i < count; i++)//do twice seprately to maintian canvas hierachy
		{
			//itemPos.Add(itemAnchor + (i * itemInterval- count*itemInterval/2) * (-Vector3.left));
			//tempObj = Instantiate(itemObj, itemAnchor + (i * itemInterval- count*itemInterval/2) * (-Vector3.left) - Vector3.forward, gameObject.transform.rotation,theCanvas.transform) as GameObject;
			itemPos.Add(DragItem.itemList[i].transform.position);
		}
		RandRelation();//generate anwser
		//==Debug==
		string temp = "";
		foreach (int i in randRelation)
		{
			temp += i.ToString() + ' ';
		}
		Debug.Log(temp);
		//===========
	}
	IEnumerator DelayCountCheck()//comparing the number of cells in the scene and the number set by user
	{
		yield return new WaitForSeconds(1f);
		if (count != DragCell.GetNextID())
		{
			Debug.LogWarning("The number of cell in the scene is not same as the count here! count:" + count.ToString() + " ids:" + DragCell.GetNextID().ToString());
		}
	}
	public void RandRelation()//randomize the relation bewteen slot & clips
	{
		List<int> temp = new List<int>();
		for (int i = 0; i < count; i++)
		{
			temp.Add(i);
		}
		while (temp.Count > 0)
		{
			int t;
			t = Random.Range(0, temp.Count);
			randRelation.Add(temp[t]);
			temp.RemoveAt(t);
		}
		int cnt = 0;
		foreach (int i in randRelation)
		{
			DragCell.cellList[cnt].id = cnt;
			DragItem.itemList[cnt].id = i;
			//Debug.Log(i);
			cnt++;
		}
	}

	public void OnEnterCallBack(int itemID, int cellID)
	{
		realRelation[cellID] = itemID;
		DebugUser();
	}

	public void OnLeaveCallBack(int itemID, int cellID)
	{
		realRelation[cellID] = -1;
		DebugUser();
	}
	public void DebugUser()
	{
		string temp = "";
		foreach (int i in realRelation)
		{
			temp += i + " "; 
		}
		Debug.Log(temp);
	}
	public void CheckAnswer()
	{
		for (int i = 0; i < count; i++)
		{
			if (realRelation[i] != i)
			{
				Debug.Log("Seq incorrect!");
				//return false;
				return;
			}
		}
		Debug.Log("Seq correct!");
		//return true;	
	}
	public void ClearUserAns()
	{
		foreach (DragCell cell in DragCell.cellList)
		{
			cell.EjectCell();
		}
		for (int i = 0; i < count; i++)
		{
			DragItem.itemList[i].transform.position = itemPos[i];
			realRelation[i] = -1;
		}
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
}
