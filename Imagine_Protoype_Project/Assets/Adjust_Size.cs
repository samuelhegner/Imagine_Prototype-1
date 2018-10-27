using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjust_Size : MonoBehaviour {
	GameObject parent;
	
	BoxCollider2D col;

	public float height;
    public float buffer;

	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
		col = GetComponent<BoxCollider2D>();

		

		if(parent.transform.childCount == 1){
			StartCoroutine(GetHeight());
		}else{
			height = Vector2.Distance(parent.transform.GetChild(0).transform.position, parent.transform.GetChild(1).transform.position) + buffer;
		}

		float width = parent.GetComponent<LineRenderer>().startWidth;
		Vector2 reSize = new Vector2(height, width);
		col.size = reSize;
	}


	IEnumerator GetHeight(){
		yield return new WaitForEndOfFrame();
		height = parent.transform.GetChild(1).GetComponent<Adjust_Size>().height;
	}
}
