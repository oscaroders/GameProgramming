using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class CollectComponent : IComponent {

    private IMediator mediator;
    private int numberOfCollectedParasites;

    public CollectComponent( IMediator mediator ) {
        this.mediator = mediator;
        this.mediator.AddComponent( this );
    }

    public void Send( int index , int value ) {
        mediator.MessageIndex( index , value , this );
    }

    public void Recive( int index , int value ) {
        switch ( index ) {
            case 1:
                //Do stuff
                break;
            default:
                break;
        }
    }

    private void Collect( int collected ) {
        numberOfCollectedParasites += collected;
        Send( 2 , numberOfCollectedParasites );
    }

    private void Disperse( int despersed ) {
        numberOfCollectedParasites -= despersed;
        Send( 2 , numberOfCollectedParasites );
    }
}