using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public IMediator Mediator {
        get;
        private set;
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
    internal HealthComponent HealthComponent {
        get; private set;
    }
    protected DeathComponent DeathComponent {
        get; private set;
    }
    internal CollectComponent CollectComponent {
        get; private set;
    }


    private InputHandler input;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private int health;

    private int drainFreqency = 5;

    private void Start() {
        input = GameManager.instance.GameInput;

        MovmentComponent = new MovmentComponent( gameObject , speed , Mediator );
        JumpComponent = new JumpComponent( gameObject , jumpForce , Mediator );
        RotationComponent = new RotationComponent( gameObject , Mediator );
        HealthComponent = new HealthComponent( health , drainFreqency , Mediator );
        DeathComponent = new DeathComponent( Mediator );
        CollectComponent = new CollectComponent( gameObject, FindObjectOfType<EnemyController>().gameObject, Mediator );

        input.Horizontal = MovmentComponent.Move;
        input.Jump = JumpComponent.Jump;
        input.Position = RotationComponent.RotateTowards;
        input.Collect = CollectComponent.Collect;
        input.Fire = CollectComponent.Fire;
    }

    private void Update() {
        HealthComponent.DrainHealth();
    }
}