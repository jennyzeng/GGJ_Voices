using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DragCell : MonoBehaviour {
	public static DragCell mouseOnCell;
	public Vector3 anchorOffset;
	bool isEntered = false;
	Image img;
	public Color onEnterColor;
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
		img.color = Color.white;
		//isEntered = false;
		//renderer.material.color = originalColor;
	}
	// Use this for initialization
	void Start () {
		img = this.gameObject.GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
	
	}
	public void AlignToAnchor(DragItem item)
	{
		item.transform.position = transform.position + anchorOffset;
	}

}
