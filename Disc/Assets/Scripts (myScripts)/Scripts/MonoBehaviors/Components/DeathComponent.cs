using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathComponent : MonoBehaviour, IComponent {

    public GameObject GO;
    public GameObject explosion;
    public MeshRenderer rend;
    public Animator animator;
    public Text text;

    private int killCount;

    private void Start() {
        animator = FindObjectOfType<Camera>().GetComponent<Animator>();
        text = FindObjectOfType<Text>();
    }

    public void Die() {
        


        if ( gameObject.CompareTag( "Player" ) ) {
            animator.SetTrigger( "GameOver" );
            text.text = "Game over";
            Invoke( "LoadMenu" , 5 );
        } else {
            killCount++;
            if ( killCount > 4 * GameManager.INSTANCE.difficultyMultipier ) {
                animator.SetTrigger( "GameOver" );
                text.text = "Win";
                Invoke( "LoadMenu" , 5 );
            }
            DestroyObject();
        }
    }

    private void LoadMenu() {
        GameManager.INSTANCE.ChangeGameState( GameManager.GameState.MAINMENU );
    }

    private void DestroyObject() {

        ServiceLocator.GetAudio().PlaySound( "KillEnemy" , gameObject );
        ServiceLocator.GetAudio().PlaySound( "Explosion" , gameObject );
        GameObject tempExplosion = Instantiate( explosion , transform );
        rend.enabled = false;

        IEnumerator corutine = ResetExplosion( GO );
        StartCoroutine( corutine );
    }

    private IEnumerator ResetExplosion( GameObject go ) {
        yield return new WaitForSeconds( 2 );
        Destroy( go );
    }

    public void OnDisable() {
        EventManager.StopListening( "DeathEvent" , Die );
    }

    public void OnEnable() {
        EventManager.StartListening( "DeathEvent" , Die );
    }

    public void Send( string message , GameObject thing , float value ) {
        //Do Stuff
    }

    public void Recive( string message , GameObject thing , float value ) {
        //Do Stuff
    }
}