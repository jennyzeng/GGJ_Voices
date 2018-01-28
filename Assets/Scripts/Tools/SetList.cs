using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetList : MonoBehaviour {

	public List<DragCell> cells = new List<DragCell>();
	public List<DragItem> items = new List<DragItem>();
	// Use this for initialization
	void Awake () {
		DragCell.cellList = cells;
		DragItem.itemList = items;
	}
}
