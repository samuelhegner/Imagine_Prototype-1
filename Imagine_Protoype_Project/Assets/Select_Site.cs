using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Site : MonoBehaviour {

    bool showing;

    public GameObject popUp;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SelectTheSite(){
        print("test");
        player.GetComponent<Player_Movement_Map>().location = transform.position;
        showing = true;
        popUp.SetActive(showing);
    }

    public void TurnOffPopUp(){
        showing = false;
        popUp.SetActive(showing);
    }
}
