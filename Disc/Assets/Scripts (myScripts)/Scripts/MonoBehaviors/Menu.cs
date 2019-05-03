using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Animator animator;
    public Text controlls_Text;
    public GameObject PanelMain;
    public GameObject CreditsCanvas;
    public GameObject DifficultyPanel;
    private bool isTutorialRunning;

    #region tutorial Setup
    public PlayerController playerController;
    public MovmentComponent movmentComponent;
    public JumpComponent jumpComponent;
    public CollectComponent collectComponent;
    public FireComponent fireComponent;
    public GameObject parasite;
    private MovmentComponent paraiteMove;
    #endregion

    public enum Tutorial_States {
        PRE_START,
        START,
        MOVE_RIGHT,
        MOVE_LEFT,
        JUMP,
        COLLECT,
        FIRE,
    }

    private Tutorial_States currentTutorialState;

    private void Start() {
        currentTutorialState = Tutorial_States.PRE_START;
        paraiteMove = parasite.GetComponent<MovmentComponent>();
        parasite.SetActive( false );
        CreditsCanvas.SetActive( false );
        DifficultyPanel.SetActive( false );
    }

    private void Update() {
        if ( isTutorialRunning ) {
            tutorial();
        }
    }

    public void tutorial() {
        switch ( currentTutorialState ) {
            case Tutorial_States.PRE_START:

                animator.SetTrigger( "ZoomIn" );
                currentTutorialState = Tutorial_States.START;
                break;
            case Tutorial_States.START:
                controlls_Text.text = "Press RIGHT";
                DebugLogging.CustomDebug( "here" );
                playerController.enabled = true;
                movmentComponent.enabled = true;

                if ( Input.GetKeyDown( KeyCode.D ) || Input.GetKeyDown( KeyCode.RightArrow ) ) {
                    currentTutorialState = Tutorial_States.MOVE_RIGHT;
                }

                break;
            case Tutorial_States.MOVE_RIGHT:
                controlls_Text.text = "Press LEFT";

                if ( Input.GetKeyDown( KeyCode.A ) || Input.GetKeyDown( KeyCode.LeftArrow ) ) {
                    currentTutorialState = Tutorial_States.MOVE_LEFT;
                }

                break;
            case Tutorial_States.MOVE_LEFT:
                controlls_Text.text = "Press SPACE";
                jumpComponent.enabled = true;

                if ( Input.GetKeyDown( KeyCode.Space ) ) {
                    currentTutorialState = Tutorial_States.JUMP;
                }

                break;
            case Tutorial_States.JUMP:
                controlls_Text.text = "RIGHT click to collect parasite in range";
                collectComponent.enabled = true;
                parasite.SetActive( true );
                paraiteMove.Move( -1 );

                if ( Input.GetKeyDown( KeyCode.Mouse1 ) && collectComponent.numberOfCollectedParasites > 0 ) {
                    currentTutorialState = Tutorial_States.COLLECT;
                    parasite.SetActive( false );
                }

                break;
            case Tutorial_States.COLLECT:
                controlls_Text.text = "LEFT click fire parasite";
                fireComponent.enabled = true;

                if ( Input.GetKeyDown( KeyCode.Mouse0 ) ) {
                    currentTutorialState = Tutorial_States.FIRE;
                }

                break;
            case Tutorial_States.FIRE:
                controlls_Text.text = string.Empty;

                isTutorialRunning = false;
                animator.SetTrigger( "ZoomOut" );
                PanelMain.SetActive( true );

                playerController.enabled = false;
                movmentComponent.enabled = false;
                jumpComponent.enabled = false;
                collectComponent.enabled = false;
                fireComponent.enabled = false;

                break;
        }
    }

    public void StartTutorial() {
        isTutorialRunning = true;
        PanelMain.SetActive( false );
    }

    public void StartGame() {
        Invoke( "SceneLoad" , 1 );
    }

    private void SceneLoad() {
        GameManager.INSTANCE.ChangeGameState(GameManager.GameState.GAME);
        //SceneManager.LoadScene( "GameScene" );
    }

    public void QuitGame() {
        Application.Quit();

    }

    public void GoToCredits() {
        animator.SetTrigger( "ToCredits" );
        PanelMain.SetActive( false );

        Invoke( "Credits" , 1.3f );
    }

    private void Credits() {
        CreditsCanvas.SetActive( true );
    }

    public void GoFromCredits() {
        animator.SetTrigger( "FromCredits" );
        CreditsCanvas.SetActive( false );
        PanelMain.SetActive( true );
    }

    public void Easy() {
        GameManager.INSTANCE.ChangeDifficultyLevel( GameManager.DifficultyLevel.EASY );
    }
    public void Medel() {
        GameManager.INSTANCE.ChangeDifficultyLevel( GameManager.DifficultyLevel.MODERATE );
    }
    public void Hard() {
        GameManager.INSTANCE.ChangeDifficultyLevel( GameManager.DifficultyLevel.HARD );
    }

    public void DifficultySettings() {
        PanelMain.SetActive( false );
        DifficultyPanel.SetActive( true );
    }

    public void BackFromDiff() {
        PanelMain.SetActive( true );
        DifficultyPanel.SetActive( false );
    }
}