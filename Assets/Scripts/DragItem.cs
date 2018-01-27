using UnityEngine;
using System.Collections;

public class DragItem : MonoBehaviour {

	static public bool isDragging = false;
	static public DragItem draggingItem;
	private Color mouseOverColor = Color.blue;
	private Color originalColor = Color.yellow;
	private bool dragging = false;
	private float distance;

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
		isDragging = true;//global
		dragging = true;
	}

	void OnMouseUp()
	{
		draggingItem = null;
		isDragging = false;//global
		dragging = false;
		if (DragCell.mouseOnCell)
		{
			DragCell.mouseOnCell.AlignToAnchor(this);
		}
	}
	// Use this for initialization
	void Start () {
	
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
