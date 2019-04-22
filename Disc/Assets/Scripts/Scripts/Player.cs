using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class Player : CharacterController {

    [SerializeField]
    private GameObject WorldOrgin;
    private Vector3 FreezedZPosition;

    private InputHandler gameInput;

    private void Start() {
        gameInput = new InputHandler(); //GameManager.instance.GameInput;
        gameInput.Horizontal = Move;
        gameInput.Jump = Jump;

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        gameInput.InputCheck();
    }

    public override void Move( float direction ) {
        WorldOrgin.transform.Rotate( Vector3.up , direction * speed * Time.deltaTime );

        float sqrMagnitude = transform.position.sqrMagnitude;
        if ( !( sqrMagnitude - differ < this.sqrMagnitude && sqrMagnitude + differ > this.sqrMagnitude ) )
            SetMagnitude( magnitude );
    }
}