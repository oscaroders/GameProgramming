using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public IMediator Mediator {
        get;
        private set;
    } = new Mediator();
    private Transform target;
    private MovmentComponent movmentComponent;
    private JumpComponent jumpComponent;
    private RotationComponent rotationComponent;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    void Start() {
        target = FindObjectOfType<PlayerController>().gameObject.transform;
        movmentComponent = new MovmentComponent( gameObject , speed , Mediator );
        jumpComponent = new JumpComponent( gameObject , jumpForce , Mediator);
        rotationComponent = new RotationComponent( gameObject, Mediator );
    }

    void Update() {
        movmentComponent.Move( -1 );
        rotationComponent.RotateTowards( target );
    }
}