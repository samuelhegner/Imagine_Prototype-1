using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Site : MonoBehaviour {

    bool showing;

    public GameObject popUp;

    public void SwitchPopUp(){
        showing = !showing;
        popUp.SetActive(showing);
    }

    public void TurnOffPopUp(){
        showing = false;
        popUp.SetActive(showing);
    }
}
