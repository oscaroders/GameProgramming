using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public interface IComponent {
    void Send( int index );
    void Recive( int index );
}