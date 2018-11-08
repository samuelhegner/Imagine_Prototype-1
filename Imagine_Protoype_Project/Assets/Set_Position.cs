using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Position : MonoBehaviour {

	public bool activated;

	public float buffer = 10;

	Camera cam;

	// Use this for initialization
	void Start () {
		activated = false;
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated == false){
			Vector3 newPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth/2, cam.pixelHeight + buffer, 0));
			newPos.z = 0f;
			transform.position = newPos;
		}

	}
}
