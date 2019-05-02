using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class GroundPunch : MonoBehaviour {

    Rigidbody rigidbody;

    void Start() {
        rigidbody = GetComponentInParent<Rigidbody>();
    }

    public void FreezeVelocity() {
        rigidbody.AddForce( Vector3.up * 200 );
        rigidbody.velocity = Vector3.zero;

    }

    public void DownForce() {
        rigidbody.AddForce(-Vector3.up * 750);
    }
}