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

    private void FireAnimation() {
        modelAnimator.SetTrigger( "Atk_Forward" );
    }

    private void CollectAnimation() {
        modelAnimator.SetTrigger( "Atk_Left" );
    }

    public void ResetJump() {
        IdleAnimation();
    }

    public void OnEnable() {
        EventManager.StartListening( "IdleAnimation" , IdleAnimation );
        EventManager.StartListening( "JumpAnimation" , JumpAnimation );
        EventManager.StartListening( "ThirdJumpAnimation" , ThirdJumpAnimation );
        EventManager.StartListening( "GroundPunchAnimation" , GroundPunchAnimation );
        EventManager.StartListening( "FireAnimation" , FireAnimation );
        EventManager.StartListening( "CollectAnimation" , CollectAnimation );
    }

    public void OnDisable() {
        EventManager.StopListening( "IdleAnimation" , IdleAnimation );
        EventManager.StopListening( "JumpAnimation" , JumpAnimation );
        EventManager.StopListening( "ThirdJumpAnimation" , ThirdJumpAnimation );
        EventManager.StopListening( "GroundPunchAnimation" , GroundPunchAnimation );
        EventManager.StopListening( "FireAnimation" , FireAnimation );
        EventManager.StopListening( "CollectAnimation" , CollectAnimation );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}