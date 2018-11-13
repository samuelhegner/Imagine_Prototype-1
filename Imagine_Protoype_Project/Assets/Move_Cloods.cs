using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Cloods : MonoBehaviour {

	float countdown;
	public float maxCountdown;
	public float speed;

	public bool x;

	Vector3 idlePos;
	Vector3 movePos;

	void Start () {
		idlePos = transform.position;
		if(x){
			movePos = new Vector3(transform.parent.transform.position.x, transform.position.y, 0);
		}else{
			movePos = new Vector3(transform.position.x, transform.parent.transform.position.y, 0);
		}
	}
	
	void Update () {
		if(countdown > 0){
			countdown -= Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, movePos, Time.deltaTime * speed);
		}else{
			transform.position = Vector3.Lerp(transform.position, idlePos, Time.deltaTime * speed/2f);
		}
	}

	public void ResetTimer(){
		countdown = maxCountdown;
	}
}
