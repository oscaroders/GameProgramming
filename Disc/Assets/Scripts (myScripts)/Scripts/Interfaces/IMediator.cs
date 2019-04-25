using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public interface IMediator {
    void AddComponent(IComponent component);
    void MessageIndex(int index, int value, IComponent component);
}