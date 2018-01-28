using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public delegate void OnEnterCellDelegate(int itemID,int cellID);
public delegate void OnLeaveCellDelegate(int itemID,int cellID);
public delegate void OnEnterCellFailedDelegate(int itemID,int cellID);
public class DragCell : MonoBehaviour 
{
	private static int newCellCount = 0;//for creating new cell id
	private static int cellCount = 0;
	public static OnEnterCellDelegate OnEnterCell = null;
	public static OnLeaveCellDelegate OnLeaveCell = null;
	public static OnEnterCellFailedDelegate OnEnterCellFailed = null;
	public int id;
	public bool isTaken = false;
	public static DragCell mouseOnCell;//the current cell that mouse is floating on
	public Vector3 anchorOffset;//where should item be aligned 
	public static List<DragCell> cellList = new List<DragCell>();
	bool isEntered = false;
	private DragItem thisItem;
	Image img;
	public Color onEnterColor;
	private Color defaultColor;
	void OnMouseEnter()
	{
		mouseOnCell = this;
		img.color = onEnterColor;
		/*
		if (DragItem.isDragging && (!isEntered))
		{
			Debug.Log("ss");
			DragItem.draggingItem.transform.position = transform.position + anchorOffset;
			isEntered = true;
		}
		*/
	}
	void OnMouseExit()
	{
		mouseOnCell = null;
		img.color = defaultColor;
		//isEntered = false;
		//renderer.material.color = originalColor;
	}
	// Use this for initialization
	void Start () {
		img = this.gameObject.GetComponent<Image>();
		id = newCellCount;
		newCellCount++;//new id 
		cellList.Add(this);//count how many cells in total
		defaultColor = new Color(img.color.r, img.color.g, img.color.b, img.color.a);
	}

	// Update is called once per frame
	void Update () {
	
	}
	public void EnterCell(DragItem item)
	{
		isTaken = true;
		thisItem = item;
		AlignToAnchor(item);
	}
	public void AlignToAnchor(DragItem item)
	{
		item.transform.position = transform.position + anchorOffset - Vector3.forward;
	}
	public void EjectCell()
	{
		isTaken = false;
		thisItem = null;
		//TODO: modify cell list
	}
	static public int GetNextID()
	{
		return newCellCount;
	}
	public void OnDestory()
	{
		//cellList.Remove(this);
	}
}
