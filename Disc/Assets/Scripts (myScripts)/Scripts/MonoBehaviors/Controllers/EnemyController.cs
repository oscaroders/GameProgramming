using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

[RequireComponent( typeof( MovmentComponent ) , typeof( JumpComponent ) , typeof( RotationComponent ) )]
public class EnemyController : MonoBehaviour {

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
    protected FireComponent FireComponent {
        get; private set;
    }

    private Transform target;

    private int drainFreqency = 4;
    private float difficultyMultipyer = GameManager.INSTANCE.difficultyMultipier;

    private bool isCoolingDown;

    void Start() {
        target = FindObjectOfType<PlayerController>().gameObject.transform;
        MovmentComponent = GetComponent<MovmentComponent>();
        JumpComponent = GetComponent<JumpComponent>();
        RotationComponent = GetComponent<RotationComponent>();
        HealthComponent = GetComponentInChildren<HealthComponent>();
        DeathComponent = GetComponentInChildren<DeathComponent>();
        FireComponent = GetComponentInChildren<FireComponent>();
    }

    void Update() {

        RaycastHit hit;
        Ray forward = new Ray( transform.position , transform.forward );
        Ray backward = new Ray( transform.position , transform.forward * -1 );
        if ( Physics.Raycast( forward , out hit) || Physics.Raycast( backward, out hit ) ) {
            if ( hit.distance < 1.3f && Physics.Raycast(transform.position, -transform.up, 0.6f)) {
                Debug.DrawRay( transform.position , -transform.up * 0.2f , Color.red , 2f );
                JumpComponent.Jump();
            }
            if ( hit.transform.gameObject.CompareTag( "Player" ) && !isCoolingDown ) {
                isCoolingDown = true;
                FireComponent.numberOfCollectedParasites = 1;
                FireComponent.Fire();
                Invoke("ResetCoolDown", 2 / difficultyMultipyer);
            }
        }

        MovmentComponent.Move(-1);

        RotationComponent.RotateTowards( target );
        MovmentComponent.thisUpdate();
        HealthComponent.thisUpdate();
    }

    private void ResetCoolDown() {
        isCoolingDown = false;
    }
}