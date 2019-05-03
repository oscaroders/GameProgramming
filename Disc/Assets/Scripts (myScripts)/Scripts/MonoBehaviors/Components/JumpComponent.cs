using System;
using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class JumpComponent : MonoBehaviour, IComponent {

    private IMediator mediator;
    private Rigidbody rigidBody;

    [SerializeField]
    private float jumpForce;

    private float jumpCounter;
    private const float DIFFER = 2f;

    private void Start() {
        mediator = FindObjectOfType<PlayerController>().Mediator;
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Jump() {

        Vector3 jumpForce = Vector3.up * this.jumpForce;

        if ( AllowedToJump() ) {
            rigidBody.velocity = new Vector3( rigidBody.velocity.x , 0 , rigidBody.velocity.x );
            rigidBody.AddForce( jumpForce , ForceMode.Acceleration );
        }
    }

    private bool AllowedToJump() {
        RaycastHit hit = new RaycastHit();
        float secondJumpHeight = 2, thirdJumpHeight = 4;

        if ( Physics.Raycast( transform.position + Vector3.up * 0.2f , Vector3.up * -1 , out hit ) ) {
            float distance = hit.distance;

            //first jump
            if ( distance < 0.6f ) {

                ResetJumpCounter();
                if ( JumpCounter( distance ) ) {

                    ServiceLocator.GetAudio().PlaySound( "Jump" , gameObject );


                    if ( gameObject.CompareTag( "Player" ) )
                        EventManager.TriggerEvent( "JumpAnimation" );

                    return true;
                }
            }

            //second jump
            if ( distance > secondJumpHeight - DIFFER && distance < secondJumpHeight + DIFFER ) {
                if ( JumpCounter( distance ) ) {

                    ServiceLocator.GetAudio().PlaySound( "Jump" , gameObject );

                    if ( gameObject.CompareTag( "Player" ) )
                        EventManager.TriggerEvent( "JumpAnimation" );

                    return true;
                }
            }

            //third jump
            if ( distance > thirdJumpHeight - DIFFER && distance < thirdJumpHeight + DIFFER ) {
                if ( Input.GetAxisRaw( "Vertical" ) < -0.2 && JumpCounter( distance ) ) {

                    GroundPunch();
                    return false;

                } else if ( JumpCounter( distance ) ) {

                    if ( gameObject.CompareTag( "Player" ) ) {

                        ServiceLocator.GetAudio().PlaySound( "Jump" , gameObject );
                        ServiceLocator.GetAudio().PlaySound( "ThirdJump" , gameObject );
                        EventManager.TriggerEvent( "ThirdJumpAnimation" );
                    }

                    return true;
                }
            }

        }
        return false;
    }

    //GroundPunch should wipe out parasites in an area, kill enemy if land ontop and shake camera!
    private void GroundPunch() {

        if ( gameObject.CompareTag( "Player" ) ) {
            EventManager.TriggerEvent( "GroundPunchAnimation" );
            ServiceLocator.GetAudio().PlaySound( "ThirdJump" , gameObject );
        }
    }

    private bool JumpCounter( float distance = 0 ) {
        float maxNumberOfJumps = 3;
        jumpCounter++;

        if ( jumpCounter <= maxNumberOfJumps ) {
            return true;
        } else {
            if ( distance < 0.6f )
                ResetJumpCounter();
            return false;
        }
    }

    private void ResetJumpCounter() {
        jumpCounter = 0;
    }

    public void OnEnable() {
        //Do Stuff
    }

    public void OnDisable() {
        //Do Stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        mediator.MessageIndex( message , thing , value , this );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}