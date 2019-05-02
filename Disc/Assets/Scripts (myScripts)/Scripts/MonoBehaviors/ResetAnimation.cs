using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class ResetAnimation : MonoBehaviour {

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void ResetThirdJump() {
        animator.SetBool( "ThirdJump" , false);
    }

    public void ResetGroundPunch() {
        animator.SetBool( "GroundPunch" , false );
    }
}