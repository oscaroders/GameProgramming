using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class HealthComponent : IComponent {

    private IMediator mediator;
    private int health;
    private int numberOfAttackingParasites;
    private int drainFreqency;
    private float timeCount;

    public HealthComponent( int health , int drainFreqency , IMediator mediator ) {
        this.health = health;
        this.drainFreqency = drainFreqency;
        numberOfAttackingParasites = 0;

        this.mediator = mediator;
        this.mediator.AddComponent( this );
    }

    public void Send( int index , int value ) {
        mediator.MessageIndex( index , value , this );
    }

    public void Recive( int index , int value ) {
        switch ( index ) {
            case 7:
                numberOfAttackingParasites += value;
                break;
            case 2:
                //Do stuff
                break;
            default:
                break;
        }
    }

    public void DrainHealth() {

        if ( timeCount > drainFreqency ) {
            health -= numberOfAttackingParasites;
            DebugLogging.CustomDebug( "numberof parasites: " + numberOfAttackingParasites );
            DebugLogging.CustomDebug("health: " + health);
            Send( 0 , health );
            timeCount = 0;
        }

        timeCount += Time.deltaTime;
    }
}