using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour {

    LineRenderer rend;

    public GameObject BalloonPoint;
    public GameObject Prism;


    public bool drawLine;

	// Use this for initialization
	void Start () {
        rend = GetComponent<LineRenderer>();
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        rend.material = whiteDiffuseMat;
        rend.positionCount = 3;
        drawLine = false;
        rend.startWidth = 0.1f;
        rend.endWidth = 0.7f;
    }

    // Update is called once per frame
    void Update () {

        Vector3[] positions = new Vector3[] {
            transform.position,
            new Vector3(Prism.transform.position.x, Prism.transform.position.y, Prism.transform.position.z),
            new Vector3(BalloonPoint.transform.position.x, BalloonPoint.transform.position.y, BalloonPoint.transform.position.z)
             };

        if (drawLine) {
            rend.SetPositions(positions);
        }
	}
}
