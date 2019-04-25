using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class Mediator : IMediator {

    List<IComponent> components;

    public Mediator() {
        components = new List<IComponent>();
    }

    public void AddComponent( IComponent component ) {
        components.Add(component);
    }

    public void MessageIndex( int index , int value,  IComponent sendingComponent ) {
        foreach ( IComponent component in components ) {
            if ( component != sendingComponent ) {
                component.Recive(index, value);
            }
        }
    }
}