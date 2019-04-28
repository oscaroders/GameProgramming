using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class ParasiteController : MonoBehaviour {
    private Rigidbody rigidBody;

    public Transform Target {
        get;
        set;
    }
    
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        Target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    public void thisUpdate() {
        Vector3 direction =  transform.position - Target.position;
        direction.Normalize();

        Roll( direction );
    }


    //Maby we should use movement? look if component system works?
    private void Roll( Vector3 direction ) {
        rigidBody.AddTorque( new Vector3( -direction.z , 0 , direction.x ) * speed * Time.deltaTime );
        rigidBody.AddForce(-direction * 4);
    }
}