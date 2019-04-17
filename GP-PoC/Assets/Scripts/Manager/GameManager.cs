using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region Singleton
    public static GameManager instance;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }
    #endregion

    #region Input Management
    private PlayerController playerController;

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if(Input.GetAxisRaw("Horizontal") != 0) {
            float dir = Input.GetAxisRaw("Horizontal");
            playerController.MoveRound(dir);
            //Debug.Log(playerController.transform.localRotation.eulerAngles);
        }

        //if (Input.GetAxisRaw("Vertical") != 0)
        //    playerController.MoveIn(Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Jump"))
            playerController.Jump();

        if (Input.GetButtonDown("Fire1")) 
            playerController.Fire();
        
    }
    #endregion

    #region GameState
    public enum GameState {
        MainMenu,
        Game,
    }

    public GameState currentGameState;

    public void ChangeGameState(GameState gameState) {
        currentGameState = gameState;

        switch (currentGameState) {
            case GameState.MainMenu:
                //Do stuff... Run Main Menu
                break;

            case GameState.Game:
                //Do stuff... Run Game or level?
                break;

            default:
                break;
        }
    }
    #endregion
}
