using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteManager : MonoBehaviour {
    public GameObject parasite;
    private List<ParasiteController> parasites;

    void Start() {
        parasites = new List<ParasiteController>();

        for ( int i = 0 ; i < 10 ; i++ ) {
            transform.RotateAround( Vector3.zero , Vector3.up , 2 * i );
            parasites.Add( Instantiate( parasite , transform.position , transform.rotation ).GetComponent<ParasiteController>() );
        }

        Debug.Log( parasites.Count );
    }

    // Update is called once per frame
    void Update() {

        foreach ( ParasiteController pc in parasites ) {
            if ( pc.enabled )
                pc.MoveRound( pc.direction * pc.speed );
        }
    }
}