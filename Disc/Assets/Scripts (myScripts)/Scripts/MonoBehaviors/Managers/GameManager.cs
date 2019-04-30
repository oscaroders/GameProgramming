﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hermit.DebugHelp;
using UnityEngine.SceneManagement;

/// <summary>
/// GameManager
/// </summary>
public class GameManager : MonoBehaviour {

    #region Singleton
    /// <summary>
    /// Singleton pattern to ensure only one instance and to get a global point of access.
    /// </summary>
    public static GameManager INSTANCE;

    private void Awake() {

        if ( INSTANCE == null ) {
            INSTANCE = this;
            DontDestroyOnLoad( this );
        } else {
            Destroy( this );
        }
    }
    #endregion

    #region GameState
    private enum GameState {
        MAINMENU,
        GAME,
        GAMEOVER,
    }

    private GameState currentGameState;

    /// <summary>
    /// Called to change GameState and handles actions when state changes
    /// </summary>
    /// <param name="gameState">GameSate</param>
    private void ChangeGameState( GameState gameState ) {
        currentGameState = gameState;

        switch ( currentGameState ) {
            case GameState.MAINMENU:
                //Do stuff... Run Main Menu
                break;

            case GameState.GAME:
                //Do stuff... Run Game or level?
                break;

            case GameState.GAMEOVER:
                //Do stuff... make sure game is over..?
                break;

            default:
                break;
        }
    }
    #endregion 

    public float WorldMagnitude {
        get;
        private set;
    } = 30f;

    public InputHandler GameInput {
        get;
        private set;
    } = new InputHandler();

    public PlayerController playerController {
        get;
        private set;
    }

    private void Start() {
        GameInput.Quit = Quit;
        GameInput.Restart = Restart;

        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        GameInput.InputCheck();
    }

    public void StartCoroutineRemote( IEnumerator CorutineToStart ) {
        StartCoroutine( CorutineToStart );
    }

    private void Quit() {
        SceneManager.LoadScene( "MenuScene" );
    }

    private void Restart() {
        SceneManager.LoadScene( "GameScene" );
    }
}