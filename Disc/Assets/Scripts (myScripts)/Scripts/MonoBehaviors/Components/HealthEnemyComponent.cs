using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemyComponent : MonoBehaviour, IComponent {
    private IMediator mediator;

    [SerializeField]
    private float maxHealth;

    private float health;
    private float AmountOfDamage;

    private Slider HealthBar;

    private DeathComponent deathComponent;

    private void Start() {

        mediator = FindObjectOfType<PlayerController>().Mediator;

        HealthBar = GetComponentInChildren<Slider>();

        health = maxHealth;
        health = health * GameManager.INSTANCE.difficultyMultipier;

        deathComponent = GetComponent<DeathComponent>();
        AmountOfDamage = health / 3 * GameManager.INSTANCE.difficultyMultipier;
    }

    private void DrainHealth() {

        health -= AmountOfDamage;

        HealthBar.value = health / maxHealth;

        if ( health <= 0 ) {
            deathComponent.Die();
        }
    }

    private void OnTriggerEnter( Collider parasite ) {

        if ( parasite.gameObject.layer == 11 ) {

            ServiceLocator.GetAudio().PlaySound( "Hit" , gameObject );
            parasite.gameObject.SetActive( false );
            DrainHealth();
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