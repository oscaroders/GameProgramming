using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class MovmentComponent : IComponent, IMovable {

    private IMediator mediator;
    private GameObject gameObject;
    private Transform transform;
    private float speed;
    private float magnitude;
    private float sqrMagnitude;
    private const float DIFFER = 0.5f;

    /// <summary>
    /// Constructor for component class MovmentComponent.
    /// </summary>
    /// <param name="gameObject">GameObject to move</param>
    /// <param name="speed">Relative speed to move in</param>
    public MovmentComponent(GameObject gameObject, float speed, IMediator mediator ) {
        this.gameObject = gameObject;
        this.speed = speed;
        transform = gameObject.transform;
        magnitude = GameManager.instance.WorldMagnitude;
        sqrMagnitude = Mathf.Pow(magnitude, 2);

        this.mediator = mediator;
        this.mediator.AddComponent( this );
    }

    public void Send( int index ) {
        mediator.MessageIndex( index , this );
    }


    public void Recive( int index ) {
        switch ( index ) {
            case 1:
                //Do stuff
                break;
            case 2:
                //Do stuff
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Used to move charcter, and make sure character is magnitude from orgin
    /// </summary>
    /// <param name="direction">Direction <values>+1 to -1</values></param>
    public void Move( float direction ) {

        transform.RotateAround( Vector3.zero , Vector3.up , -1 * direction * speed * Time.deltaTime );

        float sqrMagnitude = transform.position.sqrMagnitude;
        if ( !( sqrMagnitude - DIFFER < this.sqrMagnitude && sqrMagnitude + DIFFER > this.sqrMagnitude ) )
            SetMagnitude( magnitude );
    }

    private void SetMagnitude( float magnitude ) {
        Vector3 position = transform.position;
        position.Normalize();
        transform.position = position * magnitude;
    }
}