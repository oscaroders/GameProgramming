using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public IMediator Mediator {
        get;
        private set;
    } = new Mediator();
    private MovmentComponent movmentComponent;
    private JumpComponent jumpComponent;
    private RotationComponent rotationComponent;
    private InputHandler input;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    void Start() {
        input = GameManager.instance.GameInput;
        movmentComponent = new MovmentComponent(gameObject, speed, Mediator);
        jumpComponent = new JumpComponent(gameObject, jumpForce, Mediator);
        rotationComponent = new RotationComponent(gameObject, Mediator);

        input.Horizontal = movmentComponent.Move;
        input.Jump = jumpComponent.Jump;
        input.Position = rotationComponent.RotateTowards;
    }

    void Update() {

    }
}