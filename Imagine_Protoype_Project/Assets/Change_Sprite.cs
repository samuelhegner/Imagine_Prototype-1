using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Sprite : MonoBehaviour {

	public Sprite[] sprites = new Sprite[3];
	// Use this for initialization
	void Awake () {
		int ran = Random.Range(0, 3);

		GetComponent<SpriteRenderer>().sprite = sprites[ran];
		PolygonCollider2D col = gameObject.AddComponent<PolygonCollider2D>();
		col.isTrigger = true;
	}
}
