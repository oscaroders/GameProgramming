using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class Player : CharacterController {

    private InputHandler gameInput;

    private void Start() {
        #region Input Setup
        gameInput = GameManager.instance.GameInput;
        gameInput.Horizontal = Move;
        gameInput.Jump = Jump;
        gameInput.Fire = Fire;
        gameInput.Collect = GatherParasites;
        #endregion

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        gameInput.InputCheck();
        DrainHealth();
    }
}