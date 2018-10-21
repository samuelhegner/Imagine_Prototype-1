using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Objects : MonoBehaviour {

    Camera cam;

    float yOffScreen;
    float extra;

    public GameObject testSquare;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        //yOffScreen =  cam.pixelHeight;

        //Vector3 SpawnPos = new Vector3(transform.position.x, yOffScreen, transform.position.z);
        //testSquare.transform.position = SpawnPos;
	}
}
