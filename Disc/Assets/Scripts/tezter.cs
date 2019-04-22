using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class tezter : MonoBehaviour {

    InputHandler gameInput;
    public GameObject go;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start() {
        gameInput = GameManager.instance.GameInput;
        gameInput.Jump = Testingtesting;
    }

    // Update is called once per frame
    void Update() {

        //enemy.Move( transform.position , 1 );


    }

    void Testingtesting() {
        //DebugLogging.CustomDebug("in testingtesting");
    }
}