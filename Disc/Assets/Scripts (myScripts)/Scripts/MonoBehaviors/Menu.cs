using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void StartGame() {
        Invoke("SceneLoad", 1);
    }

    private void SceneLoad() {
        SceneManager.LoadScene( "GameScene" );
    }

    public void QuitGame() {
        Application.Quit();

    }
}