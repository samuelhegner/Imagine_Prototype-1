using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Size_Camera : MonoBehaviour {

	public Pinch_Zoom_Camera pinch;

	float minCamSize;
	float maxCamSize;
	public float minScale = 1;
	public float maxScale = 10;

	Vector3 newScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		minCamSize = pinch.minZoom;
		maxCamSize = pinch.maxZoom;

		float scale = Map(Camera.main.orthographicSize, minCamSize, maxCamSize, minScale, maxScale);

		newScale = new Vector3( scale, scale, 0);

		transform.localScale = newScale;
	}

	float Map(float a, float b, float c, float d, float e)
    {
        float cb = c - b;
        float de = e - d;
        float howFar = (a - b) / cb;
        return d + howFar * de;
    }
}
