using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour {

	public GameObject createObj;
	public int quantity;
	public Vector3 offset;
	public Quaternion direction;
	public float delay;
	public bool isDestorySelf;
	public float destroyDelay;
	// Use this for ini tialization
	void Start () 
	{
		Invoke("Create", delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Create()
	{

		if(quantity>0)
		{
			/*
			if (direction != null)
				for(int i=0;i<quantity;i++)
					Instantiate(createObj, transform.position + offset, direction);//custion rotation
			else
			*/
				for(int i=0;i<quantity;i++)
					Instantiate(createObj, transform.position + offset, transform.rotation);
		}
		if (isDestorySelf)
			Destroy(this.gameObject, destroyDelay);
	}
}
