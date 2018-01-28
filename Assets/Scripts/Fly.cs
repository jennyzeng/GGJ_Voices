using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {

    float horizontalSpeed;
    float verticalSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //horizontalSpeed = Random.Range(-100, 100);
        //verticalSpeed = Random.Range(-75, 75);

        horizontalSpeed = 20; // Random.Range(-100, 100);
        //verticalSpeed = Random.Range(-75, 75);

        transform.RotateAround(Camera.main.transform.position, Vector3.up, horizontalSpeed * Time.deltaTime);
        //transform.RotateAround(Camera.main.transform.position, Vector3.forward, verticalSpeed * Time.deltaTime);

    }
}
