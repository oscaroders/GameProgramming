using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class CollectZone : MonoBehaviour, IComponent {

    IMediator mediator;
    public CollectComponent collectComponent;
    private List<ParasiteController> parasites = new List<ParasiteController>();
    private Queue<ParasiteController> queue = new Queue<ParasiteController>();
    private Stack<ParasiteController> stack = new Stack<ParasiteController>();

    private void Start() {
        PlayerController pC = FindObjectOfType<PlayerController>();
        collectComponent = pC.CollectComponent;
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
                if(stack.Count != 0)
                    collectComponent.LaunchParasite( stack.Pop() );

                break;

            case 5:
                if ( queue.Count != 0 ) {

                    while ( true ) {
                        // throws an exeptions sometimes... look into why.
                        // also Make a Mediator system where we can send information like that parasite..
                        ParasiteController pC = queue.Peek();
                        if ( parasites.Contains( pC) ) {
                            stack.Push( pC );
                            collectComponent.Parasite = pC;
                            queue.Dequeue();
                            Send( 6 , 0 );
                            break;

                        } else {

                            queue.Dequeue();
                        }
                    }
                }

                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter( Collider parasite ) {
        if ( parasite.CompareTag( "Collecteble" ) ) {
            ParasiteController pC = parasite.GetComponent<ParasiteController>();
            parasites.Add( pC );
            queue.Enqueue( pC );
        }
    }

    private void OnTriggerExit( Collider parasite ) {
        if ( parasite.CompareTag( "Collecteble" ) ) {
            ParasiteController pC = parasite.GetComponent<ParasiteController>();
            if ( parasites.Contains( pC ) )
                parasites.Remove( pC );
        }
    }
}