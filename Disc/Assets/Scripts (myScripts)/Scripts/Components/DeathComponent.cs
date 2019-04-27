using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathComponent : IComponent {

    private IMediator mediator;

    public DeathComponent( IMediator mediator ) {
        this.mediator = mediator;
        this.mediator.AddComponent( this );
    }

    public void Send( int index , int value ) {
        mediator.MessageIndex( index , value , this );
    }

    public void Recive( int index , int value ) {
        switch ( index ) {
            case 0:
                if(value <= 0)
                    Die();
                break;
            default:
                break;
        }
    }

    private void Die() {
        DebugLogging.CustomDebug("someone Died!" , size: 20, color: "red");
        Send(11, 0);
        SceneManager.LoadScene("MenuScene");
    }
}