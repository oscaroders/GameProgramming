using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class Parasite : MonoBehaviour {
    private Rigidbody rigidBody;

    private Transform target;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update() {
        Vector3 direction =  transform.position - target.position;
        direction.Normalize();

        Roll( direction );
    }


    //Maby we should use movement? look if component system works?
    private void Roll( Vector3 direction ) {
        rigidBody.AddTorque( new Vector3( -direction.z , 0 , direction.x ) * speed * Time.deltaTime );
        rigidBody.AddForce(-direction * 4);
    }
}