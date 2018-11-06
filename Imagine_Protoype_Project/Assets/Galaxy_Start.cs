using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy_Start : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			CreateUniverse();
		}
	}

	void CreateUniverse(){
		for(int i = 0; i < transform.childCount; i++){
			transform.GetChild(i);
		}
	}
}
