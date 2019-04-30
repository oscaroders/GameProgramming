using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

//Make a serious think about this!! do i really need it...

public class Mediator : IMediator {

    List<IComponent> components;

    public enum Message {
        Do_That,
        Think_About_It,
    }

    public Mediator() {
        components = new List<IComponent>();
    }

    public void AddComponent( IComponent component ) {
        components.Add( component );
    }

    public void MessageIndex( string message , GameObject thing , float value , IComponent sendingComponent ) {
        foreach ( IComponent component in components ) {
            if ( component != sendingComponent ) {
                component.Recive( message , thing , value );
            }
        }
    }
}
