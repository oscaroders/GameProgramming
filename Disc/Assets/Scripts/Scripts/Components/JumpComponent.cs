using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class JumpComponent : IComponent {

    private IMediator mediator;
    private GameObject gameObject;
    private Transform transform;
    private Rigidbody rigidBody;
    private float jumpForce;
    private float jumpCounter;
    private const float DIFFER = 2f;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameObject">Object to jump with</param>
    /// <param name="jumpForce">With how much to jump</param>
    public JumpComponent(GameObject gameObject, float jumpForce, IMediator mediator ) {
        this.gameObject = gameObject;
        this.jumpForce = jumpForce;
        transform = this.gameObject.transform;
        rigidBody = this.gameObject.GetComponent<Rigidbody>();

        this.mediator = mediator;
        this.mediator.AddComponent( this );
    }


    public void Send( int index ) {
        mediator.MessageIndex( index , this );
    }


    public void Recive( int index ) {
        switch ( index ) {
            case 1:
                //Do stuff
                break;
            case 2:
                //Do stuff
                break;
            default:
                break;
        }
    }

    public void Jump() {
        Send(1);
        Vector3 jumpForce = Vector3.up * this.jumpForce;

        DebugLogging.CustomDebug( "" + AllowedToJump() );


        if ( AllowedToJump() ) {
            rigidBody.velocity = new Vector3( rigidBody.velocity.x , 0 , rigidBody.velocity.x );
            rigidBody.AddForce( jumpForce , ForceMode.Acceleration );
        }
    }

    private bool AllowedToJump() {
        RaycastHit hit = new RaycastHit();
        float secondJumpHeight = 2, thirdJumpHeight = 4;

        if ( Physics.Raycast( transform.position , Vector3.up * -1 , out hit ) ) {
            float distance = hit.distance;

            if ( distance < 0.6f ) {
                ResetJumpCounter();
                if ( JumpCounter( distance ) ) {
                    return true;
                }
            }

            if ( distance > secondJumpHeight - DIFFER && distance < secondJumpHeight + DIFFER ) {
                if ( JumpCounter() ) {
                    return true;
                }
            }

            if ( distance > thirdJumpHeight - DIFFER && distance < thirdJumpHeight + DIFFER ) {
                if ( JumpCounter() ) {
                    return true;
                }
            }
        }
        return false;
    }

    //How to reset jumpcounter so you can´t jump forever.
    private bool JumpCounter( float distance = 0 ) {
        float maxNumberOfJumps = 3;
        float resetTime = 3f;
        jumpCounter++;

        if ( jumpCounter < maxNumberOfJumps ) {
            return true;
        } else {
            ResetJumpCounter();
            //Invoke( "ResetJumpCounter" , resetTime );
            return false;
        }
    }

    private void ResetJumpCounter() {
        jumpCounter = 0;
    }
}