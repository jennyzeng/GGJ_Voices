using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// [RequireComponent(typeof(AudioSource))]
public class DragItem : MonoBehaviour 
{
	private static int newItemCount = 0;
	public int id;
	public static bool mustMatch = false;//do force items enter cells only with same id?
	public static bool isDragging = false;
	public static DragItem draggingItem;
	public static List<DragItem> itemList = new List<DragItem>();
	private Color mouseOverColor = Color.blue;
	private Color originalColor = Color.yellow;
	private bool dragging = false;
	private float distance;
	public bool isCelled = false;
	[HideInInspector]
	public DragCell thisCell = null;
	public AudioClip dragInSound;
	[HideInInspector]
	// public AudioSource audioSource;
	public AudioClip assignedClip;
	/*
	void OnMouseEnter()
	{
		renderer.material.color = mouseOverColor;
	}

	void OnMouseExit()
	{
		renderer.material.color = originalColor;
	}
	*/
	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		draggingItem = this;
		isDragging = true;//the global one
		dragging = true;
	}

	void OnMouseUp()
	{
		draggingItem = null;
		isDragging = false;//the global one 
		dragging = false;
		if (DragCell.mouseOnCell && (DragCell.mouseOnCell.isTaken ==false))
		{
			if (mustMatch)
			{
				if (this.id == DragCell.mouseOnCell.id)
				{
					DragCell.mouseOnCell.AlignToAnchor(this);//successfully enter
					if (DragCell.OnEnterCell != null)
						DragCell.OnEnterCell(this.id, DragCell.mouseOnCell.id);
					isCelled = true;
					thisCell = DragCell.mouseOnCell;
				}
				else
				{
					if (DragCell.OnEnterCellFailed != null)
					{
						DragCell.OnEnterCellFailed(this.id, DragCell.mouseOnCell.id);//boardcast entering failed
					}
				}
			}
			else
			{	
				if (DragCell.OnEnterCell != null)
					DragCell.OnEnterCell(this.id, DragCell.mouseOnCell.id);
				DragCell.mouseOnCell.EnterCell(this);
				isCelled = true;
				thisCell = DragCell.mouseOnCell;
				// audioSource.Play();
				AudioManager.Instance.RequestPlayClip(assignedClip);
			}
		}
		else//out of cell
		{
			if(isCelled)
			{
				thisCell.EjectCell();
				isCelled = false;
				DragCell.OnLeaveCell(this.id, thisCell.id);
				thisCell = null;
			}
		}
	}
	public void PlayCustomSound(AudioClip clip)
	{
		// audioSource.clip = clip;
		// audioSource.Play();
	}

	// Use this for initialization
	void Awake () {
		// audioSource = GetComponent<AudioSource>();
		// if (dragInSound)
		// {
		// 	audioSource.clip = dragInSound;
		// }
		id = newItemCount;
		newItemCount++;//new id
		itemList.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
	}
}
