using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class RotationComponent : MonoBehaviour, IComponent {

    private IMediator mediator;

    private void Start() {
        mediator = FindObjectOfType<PlayerController>().Mediator;
    }

    public void RotateTowards( Vector2 mousePosition ) {

        Vector3 lookRotation = Vector3.Cross( Vector3.zero - transform.position , Vector3.up );

        Quaternion lookRight = Quaternion.LookRotation( -lookRotation );
        Quaternion lookLeft = Quaternion.LookRotation( lookRotation );

        if ( mousePosition.x < Screen.width / 2) {

            transform.rotation = Quaternion.Slerp( lookRight , lookLeft , 1 );
        } else {

            transform.rotation = Quaternion.Slerp( lookLeft , lookRight , 1 );
        }
    }

    // Bugs out somtimes? see what causes strange behavior.
    public void RotateTowards( Transform target ) {
        Vector3 targetUnitVector = target.position.normalized;
        float targetUnitAngle = Mathf.Asin( targetUnitVector.z );
        Vector3 thisUnitVector = transform.position.normalized;
        float thisUnitAngle = Mathf.Asin( thisUnitVector.z );

        Vector3 lookRotation = Vector3.Cross( Vector3.zero - transform.position , Vector3.up );

        Quaternion lookRight = Quaternion.LookRotation( -lookRotation );
        Quaternion lookLeft = Quaternion.LookRotation( lookRotation );

        if ( thisUnitAngle - targetUnitAngle > 0 ) {
            transform.rotation = Quaternion.Slerp( lookRight , lookLeft , 1 );
        } else {
            transform.rotation = Quaternion.Slerp( lookLeft , lookRight , 1 );
        }
    }

    public void OnDisable() {
        //Do stuff
    }

    public void OnEnable() {
        //Do stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        mediator.MessageIndex( message , thing , value , this );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}