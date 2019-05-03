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
    private int direction;

    private float difficultyMultipyer;

    private bool isCoolingDown;

    void Start() {

        direction = (int)Mathf.Sign(Random.Range(-1,1));

        difficultyMultipyer = GameManager.INSTANCE.difficultyMultipier;

        target = FindObjectOfType<PlayerController>().gameObject.transform;

        MovmentComponent = GetComponent<MovmentComponent>();
        JumpComponent = GetComponent<JumpComponent>();
        RotationComponent = GetComponent<RotationComponent>();
        DeathComponent = GetComponentInChildren<DeathComponent>();
        FireComponent = GetComponentInChildren<FireComponent>();
    }

    void Update() {

        RaycastHit hit;
        Ray forward = new Ray( transform.position , transform.forward );
        Ray backward = new Ray( transform.position , transform.forward * -1 );

        if ( Physics.Raycast( forward , out hit ) || Physics.Raycast( backward , out hit ) ) {

            if ( hit.transform.CompareTag( "Enemy" ) ) {

                direction *= -1;
            } else if ( hit.transform.gameObject.CompareTag( "Player" ) && !isCoolingDown ) {

                isCoolingDown = true;
                FireComponent.numberOfCollectedParasites = 1;
                FireComponent.Fire();

                Invoke( "ResetCoolDown" , 2 / difficultyMultipyer );

            } else if ( hit.distance < 1.1f && Physics.Raycast( transform.position + Vector3.up * 0.2f , -transform.up , 0.25f ) ) {


                //JumpComponent.Jump();
            }
        }

        MovmentComponent.Move( direction );

        RotationComponent.RotateTowards( target );
        MovmentComponent.thisUpdate();
    }

    private void ResetCoolDown() {

        isCoolingDown = false;
    }
}