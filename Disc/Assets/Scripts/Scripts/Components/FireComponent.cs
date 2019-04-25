using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class FireComponent : IComponent {

    private IMediator mediator;
    private int numberOfCollectedParasites;

    public FireComponent( IMediator mediator ) {
        this.mediator = mediator;
        this.mediator.AddComponent( this );
    }

    public void Send( int index , int value ) {
        mediator.MessageIndex( index , value , this );
    }

    public void Recive( int index , int value ) {
        switch ( index ) {
            case 0:
                //Do stuff
                break;
            default:
                break;
        }
    }

    private void Fire() {
        if ( numberOfCollectedParasites != 0 ) {

            Send( 3 , 1 );
        }
    }
}