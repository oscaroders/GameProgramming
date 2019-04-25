using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class RotationComponent : IComponent {

    private IMediator mediator;
    private GameObject gameObject;
    private Transform transform;
    private float timeCount;

    public void Send( int index ) {
        mediator.MessageIndex( index , this );
    }

    public void Recive( int index ) {
        switch ( index ) {
            case 1:
                //Do stuff
                DebugLogging.CustomDebug("hej"); //<- kallas två gånger. 
                break;
            case 2:
                //Do stuff
                break;
            default:
                break;
        }
    }


    public RotationComponent( GameObject gameObject , IMediator mediator ) {
        this.gameObject = gameObject;
        transform = this.gameObject.transform;

        this.mediator = mediator;
        this.mediator.AddComponent(this);
    }


    public void RotateTowards( Vector2 mousePosition ) {

        Vector3 lookRotation = Vector3.Cross( Vector3.zero - transform.position , Vector3.up );

        Quaternion lookRight = Quaternion.LookRotation( -lookRotation );
        Quaternion lookLeft = Quaternion.LookRotation( lookRotation );

        //for some reason Slerp dosent work here, might it be because lookRight and lookLeft is also updated? it works form the beginning? 
        //should i make a funktion that solves this? well lest waiit for camera...
        if ( mousePosition.x < Screen.width / 2 ) {
            transform.rotation = Quaternion.Slerp( lookRight , lookLeft , timeCount );
        } else {
            transform.rotation = Quaternion.Slerp( lookLeft , lookRight , timeCount );
        }

        timeCount = timeCount + Time.deltaTime;
    }


    public void RotateTowards( Transform target ) {
        Vector3 targetUnitVector = target.position.normalized;
        float targetUnitAngle = Mathf.Asin( targetUnitVector.z );
        Vector3 thisUnitVector = transform.position.normalized;
        float thisUnitAngle = Mathf.Asin( thisUnitVector.z );

        Vector3 lookRotation = Vector3.Cross( Vector3.zero - transform.position , Vector3.up );

        Quaternion lookRight = Quaternion.LookRotation( -lookRotation );
        Quaternion lookLeft = Quaternion.LookRotation( lookRotation );

        if ( thisUnitAngle - targetUnitAngle > 0 ) {
            transform.rotation = Quaternion.Slerp( lookRight , lookLeft , timeCount );
        } else {
            transform.rotation = Quaternion.Slerp( lookLeft , lookRight , timeCount );
        }

        timeCount = timeCount + Time.deltaTime;
    }
}