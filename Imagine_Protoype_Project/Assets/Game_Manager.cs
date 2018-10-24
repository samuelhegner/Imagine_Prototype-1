using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void LoadScene(string SceneName, float timeUntilLoad){
        //StartCoroutine here on the instance

    }

    public static IEnumerator LoadInTime(float time, string name){
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(name);
    }
}
