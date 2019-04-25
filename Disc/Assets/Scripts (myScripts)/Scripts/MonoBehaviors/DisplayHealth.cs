using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour, IComponent {

    IMediator mediator;
    public Text text;
    public Text text2;

    public void Send( int index , int value ) {
        mediator.MessageIndex( index , value , this );
    }

    public void Recive( int index , int value ) {
        switch ( index ) {
            case 11:
                //Do stuff.. akka set text
                text2.text = "GameOver";
                break;
            case 10:
                //Do stuff.. akka set text
                text.text = "Health " + value.ToString();
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start() {
        mediator = FindObjectOfType<PlayerController>().Mediator;
        mediator.AddComponent( this );
    }
}