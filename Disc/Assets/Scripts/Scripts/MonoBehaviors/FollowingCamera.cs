using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {

    public Transform followTrans;
    public float distanceInFrontOf;
    public float distanceToSideOf;
    public float distanceOver;
    Vector3 offset1;
    Vector3 offset2;
    bool turn;
    Vector3 velocity;

    float currentLerpTime = 0;
    float lerpTime = 2f;
    float offsetFollow;

    // Start is called before the first frame update
    void Start() {

        offset1 = Vector3.right * distanceInFrontOf + Vector3.forward * distanceToSideOf + Vector3.up * distanceOver;
        offset2 = Vector3.right * distanceInFrontOf + Vector3.forward * -distanceToSideOf + Vector3.up * distanceOver;
        velocity = Vector3.zero;
        transform.position = followTrans.position + Vector3.right * distanceInFrontOf;
    }

    // Update is called once per frame
    void Update() {
        velocity = Vector3.zero;
        if ( turn ) {
            transform.position = Vector3.SmoothDamp( transform.position , followTrans.position + offset1 , ref velocity , 0.08f );

            if ( currentLerpTime < lerpTime ) {
                currentLerpTime += Time.deltaTime;
            }

            if ( offsetFollow < 1.75f ) {
                float percent = currentLerpTime / lerpTime;
                offsetFollow = Mathf.Lerp( -2 , 2 , percent );
            } else if ( offsetFollow < 1.999f ) {
                offsetFollow = Mathf.Lerp( offsetFollow , 2 , 0.5f );
            } else {
                offsetFollow = 2;
            }

            transform.rotation = Quaternion.LookRotation( ( followTrans.position + Vector3.forward * offsetFollow ) - transform.position , Vector3.up );
        } else {
            transform.position = Vector3.SmoothDamp( transform.position , followTrans.position + offset2 , ref velocity , 0.08f );

            if ( currentLerpTime < lerpTime ) {
                currentLerpTime += Time.deltaTime;
            }

            if ( offsetFollow > -1.75f ) {
                float percent = currentLerpTime / lerpTime;
                offsetFollow = Mathf.Lerp( 2 , -2 , percent );
            } else if ( offsetFollow > -1.999f ) {
                offsetFollow = Mathf.Lerp( offsetFollow , -2 , 0.5f );
            } else {
                offsetFollow = -2;
            }

            transform.rotation = Quaternion.LookRotation( ( followTrans.position + Vector3.forward * offsetFollow ) - transform.position , Vector3.up );
            
        }

        if ( Input.GetKeyDown( KeyCode.V ) ) {
            turn = !turn;
            currentLerpTime = 0;
        }

    }
}