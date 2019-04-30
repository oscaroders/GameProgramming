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

    private Collider collider;

    private float timeCount;

    private void Start() {
        MovmentComponent = GetComponent<MovmentComponent>();
        collider = GetComponent<Collider>();
    }

    private void Update() {
        MovmentComponent.thisUpdate();
        MovmentComponent.Move( direction );

        if ( timeCount > 5f ) {
            //Do cool poff stuff..
            Destroy(gameObject);
        }
        timeCount += Time.deltaTime;
    }
}