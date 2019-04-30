﻿using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
// TODO redo most of it. connect to UI so that health is displayed. and so that "Blood" show around screen edges when you loose health...
//you qhould loose health if enemy touches you and you sould bounce away.

public class HealthComponent : MonoBehaviour, IComponent {

    private IMediator mediator;

    [SerializeField]
    private int health;

    private float oldHealth = 100;

    public int numberOfAttackingParasites {
        get; private set;
    }
    private int drainFreqency = 5;
    private float timeCount;

    private void Start() {
        mediator = FindObjectOfType<PlayerController>().Mediator;
    }

    public void thisUpdate() {
        DrainHealth();
    }

    private void DrainHealth() {

        if ( timeCount > drainFreqency ) {
            health -= numberOfAttackingParasites;
            EventManager.TriggerEvent( "RemoveHealth" );
            Debug.Log("health: " + health);
            timeCount = 0;
            if ( health <= 0 ) {
                EventManager.TriggerEvent( "DeathEvent" );
                Debug.Log( "died " + health );
            }
        }

        timeCount += Time.deltaTime;
    }

    private void OnTriggerEnter( Collider parasite ) {

        if ( parasite.gameObject.layer == 11 ) {
            numberOfAttackingParasites++;
            parasite.gameObject.SetActive( false );
        }
    }

    public void OnDisable() {
        //Do Stuff
    }

    public void OnEnable() {
        //Do Stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        mediator.MessageIndex( message , thing , value , this );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}