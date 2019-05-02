using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class AnimationStuff : MonoBehaviour, IComponent {

    public Animator baseAnimator;
    public Animator modelAnimator;

    void Start() {
        //baseAnimator = GetComponent<Animator>();
        //modelAnimator = GetComponentInChildren<Animator>();
    }

    private void IdleAnimation() {
        baseAnimator.SetTrigger( "Idle" );
    }

    private void JumpAnimation() {
        baseAnimator.SetTrigger( "Jump" );
    }

    private void ThirdJumpAnimation() {
        modelAnimator.SetTrigger( "ThirdJump" );
    }

    private void GroundPunchAnimation() {
        modelAnimator.SetTrigger( "GroundPunch" );
    }

    public void ResetJump() {
        IdleAnimation();
    }

    public void OnEnable() {
        EventManager.StartListening( "IdleAnimation" , IdleAnimation );
        EventManager.StartListening( "JumpAnimation" , JumpAnimation );
        EventManager.StartListening( "ThirdJumpAnimation" , ThirdJumpAnimation );
        EventManager.StartListening( "GroundPunchAnimation" , GroundPunchAnimation );
    }

    public void OnDisable() {
        EventManager.StopListening( "IdleAnimation" , IdleAnimation );
        EventManager.StopListening( "JumpAnimation" , JumpAnimation );
        EventManager.StopListening( "ThirdJumpAnimation" , ThirdJumpAnimation );
        EventManager.StopListening( "GroundPunchAnimation" , GroundPunchAnimation );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}