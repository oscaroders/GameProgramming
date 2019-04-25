using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class CollectComponent : IComponent {

    private IMediator mediator;
    private Transform transform;
    private Transform target;
    private int numberOfCollectedParasites;

    internal ParasiteController Parasite {
        get;
        set;
    }

    public CollectComponent(GameObject gameObject, GameObject target, IMediator mediator ) {
        transform = gameObject.transform;

        this.target = target.transform;
        this.mediator = mediator;
        this.mediator.AddComponent( this );
    }

    public void Send( int index , int value ) {
        mediator.MessageIndex( index , value , this );
    }

    public void Recive( int index , int value ) {
        switch ( index ) {
            case 6:

                //Do stuff .... Like shoot lightning or something..
                Parasite.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void Collect() {
        Send( 5, 0);
        numberOfCollectedParasites++;
        Send( 2 , numberOfCollectedParasites );
    }

    private void Disperse( int despersed ) {
        numberOfCollectedParasites -= despersed;
        Send( 2 , numberOfCollectedParasites );
    }

    public void Fire() {
        if ( numberOfCollectedParasites != 0 ) {
            Send( 4 , 0 );
        }
    }

    public void LaunchParasite( ParasiteController parasiteController ) {
        parasiteController.gameObject.transform.position = transform.position + transform.forward.normalized * 1.5f;
        parasiteController.Target = target;
        parasiteController.gameObject.SetActive( true );
        parasiteController.gameObject.GetComponent<Rigidbody>().AddForce( transform.forward.normalized * 1000 ); 
    }
}