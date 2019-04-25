using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public interface IComponent {
    void Send( int index, int value );
    void Recive( int index, int value );
}