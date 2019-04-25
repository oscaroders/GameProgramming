using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class EnemyController : MonoBehaviour {

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

    private Transform target;

    private float timeCount;
    private int direction = 1;
    private int random = 6;
    private int health = 50;
    private int drainFreqency = 4;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    void Start() {
        target = FindObjectOfType<PlayerController>().gameObject.transform;
        MovmentComponent = new MovmentComponent( gameObject , speed , Mediator );
        JumpComponent = new JumpComponent( gameObject , jumpForce , Mediator);
        RotationComponent = new RotationComponent( gameObject, Mediator );
        HealthComponent = new HealthComponent( health , drainFreqency , Mediator );
        DeathComponent = new DeathComponent( Mediator );
        CollectComponent = new CollectComponent( gameObject , FindObjectOfType<EnemyController>().gameObject , Mediator );
    }

    void Update() {

        if ( ( transform.position - target.position ).magnitude < 5 ) {
            CollectComponent.Fire();
        }

        if ( Time.frameCount % 10 == 0 ) {
            CollectComponent.Collect();
        }

        if ( timeCount > 4 ) {
            direction = -direction;
            timeCount = 0;
            random = Random.Range(3, 9);
        }
        MovmentComponent.Move( direction );
        RotationComponent.RotateTowards( target );
        timeCount += Time.deltaTime;

        HealthComponent.DrainHealth();
    }
}