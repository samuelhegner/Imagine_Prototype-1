using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Menu : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene("Map_Scene");
    }
}
