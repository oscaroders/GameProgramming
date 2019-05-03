using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent( typeof( MovmentComponent ) , typeof( JumpComponent ) , typeof( RotationComponent ) )]
public class PlayerController : MonoBehaviour {

    internal Mediator Mediator {
        get; private set;
    } = new Mediator();

    protected MovmentComponent MovmentComponent {
        get; private set;
    }
    protected JumpComponent JumpComponent {
        get; private set;
    }
    protected RotationComponent RotationComponent {
        get; private set;
    }
    protected CollectComponent CollectComponent {
        get; private set;
    }
    protected FireComponent FireComponent {
        get; private set;
    }
    protected HealthComponent HealthComponent {
        get; private set;
    }

    private InputHandler input;

    private void Start() {

        input = GameManager.INSTANCE.GameInput;
        //DontDestroyOnLoad( gameObject );

        MovmentComponent = GetComponent<MovmentComponent>();
        JumpComponent = GetComponent<JumpComponent>();
        RotationComponent = GetComponent<RotationComponent>();
        CollectComponent = GetComponentInChildren<CollectComponent>();
        FireComponent = GetComponentInChildren<FireComponent>();
        HealthComponent = GetComponentInChildren<HealthComponent>();

        input.Horizontal = MovmentComponent.Move;
        input.Jump = JumpComponent.Jump;
        input.Position = RotationComponent.RotateTowards;
        input.Collect = CollectComponent.Collect;
        input.Fire = FireComponent.Fire;
    }

    private void Update() {

        MovmentComponent.thisUpdate();
        HealthComponent.thisUpdate();

       

    }
}
