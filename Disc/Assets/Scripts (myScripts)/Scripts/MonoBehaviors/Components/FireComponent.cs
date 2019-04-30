using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class FireComponent : MonoBehaviour, IComponent {

    private IMediator mediator;
    private CollectComponent collectComponent;

    [SerializeField]
    private GameObject parasiteBulletPrefab;

    private int numberOfCollectedParasites;

    private void Start() {
        mediator = FindObjectOfType<PlayerController>().Mediator;
        collectComponent = GetComponent<CollectComponent>();
    }

    public void Fire() {
        UpdateNumberOfCollectedParasites();
        if ( numberOfCollectedParasites != 0 ) {

            GameObject PB = Instantiate( parasiteBulletPrefab );
            PB.GetComponent<ParasiteBulletController>().direction = -1;
            EventManager.TriggerEvent( "Disperse" );
        }
    }

    private void UpdateNumberOfCollectedParasites() {
        numberOfCollectedParasites = collectComponent.numberOfCollectedParasites;
    }

    public void OnDisable() {
        
    }

    public void OnEnable() {
        
    }

    public void Send( string message , GameObject thing , float value ) {
        mediator.MessageIndex( message , thing , value , this );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}