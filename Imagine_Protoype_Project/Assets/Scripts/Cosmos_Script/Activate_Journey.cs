﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Journey : MonoBehaviour {

    Camera cam;
    GameObject player;
    Animator anim;


	// Use this for initialization
	void Start () {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = cam.GetComponent<Animator>();
	}

    void OnMouseDown()
    {
        anim.SetTrigger("Start");
        StartCoroutine("StopAnimation");
    }

    IEnumerator StopAnimation() {
        yield return new WaitForSeconds(3f);
        cam.GetComponent<Animator>().enabled = false;
        cam.GetComponent<Follow_Player_Camera>().enabled = true;
    }
}