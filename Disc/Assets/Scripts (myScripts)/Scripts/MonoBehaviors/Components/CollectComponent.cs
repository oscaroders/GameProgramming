using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.Events;

//TODO Remake this shit!!!! And also make fire its own component!!!


public class CollectComponent : MonoBehaviour, IComponent {

    public int numberOfCollectedParasites {
        get; private set;
    }

    private IMediator mediator;
    private particleAttractorLinear particles;

    private List<GameObject> collectebleParasites;

    private void Start() {
        mediator = FindObjectOfType<PlayerController>().Mediator;

        particles = FindObjectOfType<particleAttractorLinear>();
        particles.gameObject.SetActive( false );

        collectebleParasites = new List<GameObject>();
    }

    public void Collect() {

        if ( collectebleParasites.Count != 0 ) {

            ServiceLocator.GetAudio().PlaySound( "Collect1" , gameObject );
            EventManager.TriggerEvent( "CollectAnimation" );

            numberOfCollectedParasites++;

            particles.gameObject.SetActive( true );
            particles.Target = collectebleParasites[0].transform;

            EventManager.TriggerEvent( "ParticleBurst" );

            collectebleParasites[0].SetActive( false );
            collectebleParasites.RemoveAt(0);
        }
    }

    public void DeactivateParticles() {

        particles.gameObject.SetActive( false );
    }

    public void Disperse() {

        numberOfCollectedParasites--;
    }

    private void OnTriggerEnter( Collider parasite ) {

        if ( parasite.gameObject.CompareTag("Parasite") ) {

            collectebleParasites.Add( parasite.gameObject );
        }
    }

    private void OnTriggerExit( Collider parasite ) {

        if ( parasite.gameObject.layer == 11 ) {

            if ( collectebleParasites.Contains( parasite.gameObject ) ) {

                collectebleParasites.Remove( parasite.gameObject );
            }
        }
    }

    public void OnEnable() {
        EventManager.StartListening( "DeactivateParticles" , DeactivateParticles );
        EventManager.StartListening( "Disperse" , Disperse );
    }

    public void OnDisable() {
        EventManager.StopListening( "DeactivateParticles" , DeactivateParticles );
        EventManager.StopListening( "Disperse" , Disperse );
    }

    public void Send( string message , GameObject thing , float value ) {
        mediator.MessageIndex( message , thing , value , this );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}