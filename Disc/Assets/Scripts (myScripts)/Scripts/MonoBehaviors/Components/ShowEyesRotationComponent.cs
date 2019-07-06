using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class ShowEyesRotationComponent : MonoBehaviour, IComponent {



    private void ShowEyesLeft() {
        transform.localEulerAngles = Vector3.up * 150;
    }

    private void ShowEyesRight() {
        transform.localEulerAngles = Vector3.up * -150;
    }

    public void OnDisable() {
        EventManager.StopListening( "ShowEyesLeft" , ShowEyesLeft );
        EventManager.StopListening( "ShowEyesRight" , ShowEyesRight );
    }

    public void OnEnable() {
        EventManager.StartListening( "ShowEyesLeft" , ShowEyesLeft );
        EventManager.StartListening( "ShowEyesRight" , ShowEyesRight );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //
    }

    public void Send( string message , GameObject thing , float value ) {
        //
    }
}