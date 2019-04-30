using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO Remake this shiiiit!!!!

public class DeathComponent : MonoBehaviour, IComponent {

    public DeathComponent( ) {

    }

    private void Die() {
        DebugLogging.CustomDebug("someone Died!" , size: 20, color: "red");
        SceneManager.LoadScene("MenuScene");
    }

    public void OnDisable() {
        //Do Stuff
    }

    public void OnEnable() {
        //Do Stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        //Do Stuff
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}