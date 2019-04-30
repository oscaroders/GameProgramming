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

            GameObject PB = Instantiate( parasiteBulletPrefab, transform.position + (transform.forward * 1.2f) , transform.rotation );
            PB.GetComponent<ParasiteBulletController>().direction = Input.mousePosition.x < Screen.width / 2 ? -1 : 1;

            if (Input.mousePosition.y > Screen.height / 2) {

                PB.GetComponent<Rigidbody>().AddForce( Vector3.up * Input.mousePosition.y * 0.5f);
            }

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