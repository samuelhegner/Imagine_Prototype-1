using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail_Effect : MonoBehaviour {

	bool trail;

	float emission;
	public float emissionCap = 25f;

	ParticleSystem system;
	ParticleSystem.EmissionModule em;
	void Start(){
		system = GetComponent<ParticleSystem>();
		em = system.emission;
		emission = 0;
	}

	void Update(){
		if(trail == true){
			if(emission <= emissionCap){
				emission += Time.deltaTime;
			}
		}else if(trail == false){
			if(emission > 0){
				emission -= Time.deltaTime * 2f;
			}
		}

		em.rateOverTime = emission;
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.tag == "Trail"){
			GetComponent<Player_Movement_Cosmos>().trail = true;
			trail = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Trail"){
			GetComponent<Player_Movement_Cosmos>().trail = false;
			trail = false;
		}
	}
}
