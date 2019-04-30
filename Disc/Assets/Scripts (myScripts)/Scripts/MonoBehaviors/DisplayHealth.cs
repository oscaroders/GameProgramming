using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.UI;

//Make a UI system instead....

public class DisplayHealth : MonoBehaviour, IComponent {

    public Text text;
    public Text text2;

    public void OnDisable() {
        //Do Stuff
    }

    public void OnEnable() {
        //Do Stuff
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        //Do Stuff
    }


    // Start is called before the first frame update
    void Start() {
    }
}