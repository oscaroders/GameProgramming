using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public interface IMediator {
    void AddComponent( IComponent component );
    void MessageIndex( string message , GameObject thing , float value , IComponent component );
}