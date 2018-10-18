using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_Creator : MonoBehaviour {

    public Rigidbody2D hook;

    public Weight weight;

    public GameObject pref;

    public int links;

	// Use this for initialization
	void Start () {
        GenerateRope();
	}

    void GenerateRope() {

        Rigidbody2D previousRB = hook;

        for (int i = 0; i < links; i++) {
            GameObject link = Instantiate(pref, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;



            if (i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else {
                weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }

        }
    }
}
