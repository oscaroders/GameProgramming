using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class AttackZoneEnemy : MonoBehaviour, IComponent {

    IMediator mediator;
    public HealthComponent healthComponent;

    private void Start() {
        EnemyController pC = FindObjectOfType<EnemyController>();
        healthComponent = pC.HealthComponent;
        mediator = pC.Mediator;
        mediator.AddComponent( this );
    }


    public void Send( int index , int value ) {
        mediator.MessageIndex( index , value , this );
    }

    public void Recive( int index , int value ) {
        switch ( index ) {
            case 4:
                //Do stuff
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter( Collider parasite ) {
        if ( parasite.CompareTag( "Collecteble" ) ) {
            ParasiteController pC = parasite.GetComponent<ParasiteController>();
            Send( 7 , 1 );
            pC.gameObject.SetActive( false );
        }
    }
}