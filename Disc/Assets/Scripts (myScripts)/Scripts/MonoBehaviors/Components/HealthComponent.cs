using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.UI;
// TODO redo most of it. connect to UI so that health is displayed. and so that "Blood" show around screen edges when you loose health...
//you qhould loose health if enemy touches you and you sould bounce away.

public class HealthComponent : MonoBehaviour, IComponent {

    private IMediator mediator;

    [SerializeField]
    private float health;

    private float maxHealth;

    public int numberOfAttackingParasites {
        get; private set;
    }

    public Slider HealthBar;

    private int drainFreqency = 5;
    private float timeCount;
    private float difficulty;

    private void Start() {
        maxHealth = health;
        mediator = FindObjectOfType<PlayerController>().Mediator;
        difficulty = GameManager.INSTANCE.difficultyMultipier;
    }

    public void thisUpdate() {
        DrainHealth();
    }

    private void DrainHealth() {

        if ( timeCount > drainFreqency ) {

            health -= numberOfAttackingParasites;
            EventManager.TriggerEvent( "RemoveHealth" );
            HealthBar.value = health / maxHealth;

            timeCount = 0;

            if ( health <= 0 ) {

                EventManager.TriggerEvent( "DeathEvent" );
            }
        }

        timeCount += Time.deltaTime;
    }

    private void OnTriggerEnter( Collider parasite ) {

        if ( parasite.gameObject.layer == 11 ) {

            ServiceLocator.GetAudio().PlaySound( "ParasiteAttack" , gameObject );
            EventManager.TriggerEvent( "Shake" );
            numberOfAttackingParasites++;
            parasite.gameObject.SetActive( false );
        } else if ( parasite.gameObject.layer == 10 ) {

            ServiceLocator.GetAudio().PlaySound( "ParasiteAttack" , gameObject );
            EventManager.TriggerEvent( "Shake" );
            health -= 5 * difficulty;
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