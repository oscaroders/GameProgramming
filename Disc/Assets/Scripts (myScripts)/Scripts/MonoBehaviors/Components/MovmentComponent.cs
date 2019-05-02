using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

// TODO: Implement a new thisUpdade() that sets the magnitude. remove that call from set Move()

public class MovmentComponent : MonoBehaviour, IComponent, IMovable {

    private IMediator mediator;

    [SerializeField]
    internal float speed;

    private float magnitude;
    private float sqrMagnitude;
    private const float DIFFER = 0.5f;

    private void Start() {
        mediator = FindObjectOfType<PlayerController>().Mediator;
        magnitude = GameManager.INSTANCE.WorldMagnitude;
        sqrMagnitude = Mathf.Pow( magnitude , 2 );

        if ( gameObject.CompareTag( "Enemy" ) ) {
            speed = speed * GameManager.INSTANCE.difficultyMultipier;
        }
    }

    internal void thisUpdate() {
        SetMagnitude( magnitude );
    }

    /// <summary>
    /// Used to move charcter, and make sure character is magnitude from orgin
    /// </summary>
    /// <param name="direction">Direction <values>+1 to -1</values></param>
    public void Move( float direction ) {

        transform.RotateAround( Vector3.zero , Vector3.up , -1 * direction * speed * Time.deltaTime );
    }

    private void SetMagnitude( float magnitude ) {
        Vector3 position = transform.position;
        position.Normalize();
        transform.position = position * magnitude;
    }

    public void OnEnable() {
        //Do stuff
    }

    public void OnDisable() {
        //Do stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        mediator.MessageIndex( message , thing , value , this );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}