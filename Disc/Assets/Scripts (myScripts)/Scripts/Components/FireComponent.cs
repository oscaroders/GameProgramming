using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class FireComponent : IComponent {

    private IMediator mediator;
    private Transform transform;
    private int numberOfCollectedParasites;

    public FireComponent(GameObject gameObject, IMediator mediator ) {
        transform = gameObject.transform;

        this.mediator = mediator;
        this.mediator.AddComponent( this );
    }

    public void Send( int index , int value ) {
        mediator.MessageIndex( index , value , this );
    }

    public void Recive( int index , int value ) {
        switch ( index ) {
            case 2:
                numberOfCollectedParasites = value;
                break;

            default:
                break;
        }
    }

    public void Fire() {
        if ( numberOfCollectedParasites != 0 ) {

            Send( 3 , 1 );
        }
    }
}