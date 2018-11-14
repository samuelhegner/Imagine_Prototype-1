using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Site : MonoBehaviour {

    bool showing;

    public bool loadScene;

    public GameObject popUp;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        loadScene = false;
    }

    void Update(){
        if(loadScene){
            if(Vector2.Distance(transform.position, player.transform.position)< 1f){
                transform.GetComponent<Site_Info>().LoadCorrespondingScene();
            }
        }
    }

    public void SelectTheSite(){
        showing = true;
        popUp.SetActive(showing);
    }

    public void TurnOffPopUp(){
        showing = false;
        popUp.SetActive(showing);
    }

    public void MoveToSite(){
        player.GetComponent<Player_Movement_Map>().location = transform.position;
        loadScene = true;
    }
}
