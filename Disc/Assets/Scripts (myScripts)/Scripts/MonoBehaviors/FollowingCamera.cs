using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {

    public Transform followTrans;
    Vector3 velocity = Vector3.zero;

    private void LateUpdate() {
        Vector3 offsetDirection = ( followTrans.position - Vector3.zero ) * 2f;
        offsetDirection = new Vector3(offsetDirection.x,  10, offsetDirection.z);
        transform.position = Vector3.SmoothDamp( transform.position , offsetDirection , ref velocity , 0.04f );
        transform.rotation = Quaternion.LookRotation( -offsetDirection , Vector3.up );
    }
}