using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathComponent : MonoBehaviour, IComponent {

    public GameObject GO;
    public GameObject explosion;
    public MeshRenderer rend;

    public void Die() {

        if ( gameObject.CompareTag( "Player" ) ) {

            DebugLogging.CustomDebug( "You Died!" , size: 20 , color: "red" );
            SceneManager.LoadScene( "MenuScene" );
        } else {

            DestroyObject();
        }
    }

    private void DestroyObject() {

        ServiceLocator.GetAudio().PlaySound( "KillEnemy" , gameObject );
        ServiceLocator.GetAudio().PlaySound( "Explosion" , gameObject );
        GameObject tempExplosion = Instantiate(explosion, transform);
        rend.enabled = false;

        IEnumerator corutine = ResetExplosion( GO );
        StartCoroutine(corutine);
    }

    private IEnumerator ResetExplosion(GameObject go) {
        yield return new WaitForSeconds(2);
        Destroy(go);
    }

    public void OnDisable() {
        //Do Stuff
    }

    public void OnEnable() {
        //Do Stuff
    }

    public void Send( string message , GameObject thing , float value ) {
        //Do Stuff
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}