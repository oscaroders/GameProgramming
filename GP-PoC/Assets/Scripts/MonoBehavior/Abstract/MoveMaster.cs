using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveMaster : MonoBehaviour, IMovement {

    [SerializeField] internal float jumpForce = 350;
    [SerializeField] internal float moveSpeed = 20;

    private float movementAngle;
    private Rigidbody rigidBody;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();

        moveSpeed = moveSpeed == 0 ? 20 : moveSpeed;
        jumpForce = jumpForce == 0 ? 350 : jumpForce;
    }

    public void MoveRound(float direction) {
        movementAngle = -1 * direction * moveSpeed * Time.deltaTime;
        transform.RotateAround(Vector3.zero, Vector3.up, movementAngle);
    }

    public void MoveIn(float direction) {
        Vector3 orientationVector = new Vector3();
        orientationVector = transform.position - Vector3.zero;

        Vector3 Pos = transform.position;

        if (direction < 0) {
            Pos = Pos + (orientationVector * 0.1f * direction * Time.deltaTime);
        } else if (direction > 0) {
            Pos = Pos + (orientationVector * 0.1f * direction *  Time.deltaTime);
        }

        transform.position = Pos;
    }

    public void Jump() {
        rigidBody.AddForce(0f, jumpForce, 0f);
    }
}
