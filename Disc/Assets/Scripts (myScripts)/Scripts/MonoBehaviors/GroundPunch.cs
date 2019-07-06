using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class GroundPunch : MonoBehaviour, IComponent{

    private Rigidbody rigidbody;

    void Start() {
        rigidbody = GetComponentInParent<Rigidbody>();
    }

    public void FreezeVelocity() {
        rigidbody.AddForce( Vector3.up * 200 );
        rigidbody.velocity = Vector3.zero;

    }

    public void DownForce() {
        rigidbody.AddForce(-Vector3.up * 750);
    }

    public void GroundPunchActivate() {
        ServiceLocator.GetAudio().PlaySound( "Explosion" , gameObject );
        EventManager.TriggerEvent("Shake");

        RaycastHit hit;
        Ray temp = new Ray( transform.position , -Vector3.up );
       
        if ( Physics.Raycast( temp , out hit ) ) {
            if ( hit.transform.CompareTag( "Enemy" ) ) {

                HealthEnemyComponent enemy = hit.transform.gameObject.GetComponentInChildren<HealthEnemyComponent>(); 
                enemy.health -= 100;
                enemy.DrainHealth();
            }
        }
    }

    public void Send( string message , GameObject thing , float value ) {
        
    }

    public void Recive( string message , GameObject thing , float value ) {
        
    }

    public void OnEnable() {
        
    }

    public void OnDisable() {
        
    }
}