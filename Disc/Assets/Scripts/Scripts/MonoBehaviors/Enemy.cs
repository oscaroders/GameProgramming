using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Enemy : CharacterController {

    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void Update() {
        Move( -1 );
    }
}