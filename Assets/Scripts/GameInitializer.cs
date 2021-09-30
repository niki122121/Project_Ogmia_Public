﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public GameObject player;
    public GameObject gameController;
    public string sceneToLoadAtStart;

    public delegate void GameEvent();
    public static event GameEvent gameInitialized; //Evento lanzado cuando el jugador muere, para causar una reacción global


    void Start()
    {
        //initializeGame();
    }

    public void initializeGame()
    {
        //AUDIO
            AudioManager.engine.ChangeSegmentTo(1);
        //


        UIManager.UIM.generatingLevel1.SetActive(true);

        player.SetActive(true);
        gameController.SetActive(true);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameController);

        PlayerPrefs.DeleteAll(); //Al comenzar una nueva partida, destruye todos los datos guardados de la anterior.

        gameController.GetComponent<GameController>().resetInfo();

        if (gameInitialized != null)
            gameInitialized();

        //if (sceneToLoadAtStart != null)
        //    SceneManager.LoadScene(sceneToLoadAtStart);
    }

    public void continueGame()
    {
        //AUDIO
            AudioManager.engine.ChangeSegmentTo(1);
        //

        UIManager.UIM.generatingLevel1.SetActive(true);

        player.SetActive(true);
        gameController.SetActive(true);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameController);

        ProgressTracker.PT.getSavedPieces();


        if (gameInitialized != null)
            gameInitialized();
    }
}
