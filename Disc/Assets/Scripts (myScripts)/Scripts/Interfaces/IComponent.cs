using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public interface IComponent {
    void Send( string message , GameObject thing , float value );
    void Recive( string message , GameObject thing , float value );
    void OnEnable( );
    void OnDisable( );
}