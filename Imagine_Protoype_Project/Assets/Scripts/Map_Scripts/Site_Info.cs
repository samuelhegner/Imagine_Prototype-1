using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Site_Info : MonoBehaviour {

    public enum TypeOfSite {
        Sacred,
        Regional
    }

    public TypeOfSite site;


    public string sceneName;


    public void LoadCorrespondingScene() {
       // SceneManager.LoadScene(sceneName);
       
       Game_Manager.Instance.LoadScene(sceneName, 0.8f);
       
    }
}
