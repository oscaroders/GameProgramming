using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

[RequireComponent( typeof( MovmentComponent ) )]
public class ParasiteBulletController : MonoBehaviour {

    protected MovmentComponent MovmentComponent {
        get; private set;
    }

    internal float direction;

    private void Start() {
        MovmentComponent = GetComponent<MovmentComponent>();
        MovmentComponent.speed = 30;
    }

    private void Update() {
        MovmentComponent.thisUpdate();
        MovmentComponent.Move( direction );
    }
}