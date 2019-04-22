using System;
using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class CharacterController : MonoBehaviour, IMovable {

    protected Rigidbody rigidBody;
    protected Animator animator;

    [SerializeField]
    protected float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    protected float magnitude;
    protected float sqrMagnitude;
    protected float differ = 0.5f;

    private float jumpCounter;

    void Start() {
        //magnitude = transform.position.magnitude;
        sqrMagnitude = Mathf.Pow( magnitude , 2 );
    }

    public void Jump() {
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

            if ( distance < 0.1f + differ ) {
                ResetJumpCounter();
                if ( JumpCounter( distance ) ) {
                    return true;
                }
            }

            if ( distance > secondJumpHeight - differ && distance < secondJumpHeight + differ ) {
                if ( JumpCounter() ) {
                    return true;
                }
            }

            if ( distance > thirdJumpHeight - differ && distance < thirdJumpHeight + differ ) {
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
            Invoke( "ResetJumpCounter" , resetTime );
            return false;
        }
    }

    private void ResetJumpCounter() {
        jumpCounter = 0;
    }

    /// <summary>
    /// Used to move charcter, and make sure character is magnitude from orgin
    /// </summary>
    /// <param name="direction">Direction <values>+1 to -1</values></param>
    public virtual void Move( float direction ) {

        transform.RotateAround( Vector3.zero , Vector3.up , direction * speed * Time.deltaTime );

        float sqrMagnitude = transform.position.sqrMagnitude;
        if ( !( sqrMagnitude - differ < this.sqrMagnitude && sqrMagnitude + differ > this.sqrMagnitude ) )
            SetMagnitude( magnitude );
    }

    protected void SetMagnitude( float magnitude ) {
        Vector3 position = transform.position;
        position.Normalize();
        transform.position = position * magnitude;
    }
}