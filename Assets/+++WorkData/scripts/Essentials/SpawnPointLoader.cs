using System;
using System.Collections;
using System.Collections.Generic;
using ___WorkData.Movement;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPointLoader : MonoBehaviour
{

    public Transform[] spawnPoints;
    private Transform playerTransform;
    private void OnEnable()
    {
        StartCoroutine(DelayLoad());
    }

    IEnumerator DelayLoad()
    {
        yield return null;
        GameController gameController = FindObjectOfType<GameController>();
        playerTransform = FindObjectOfType<PlayerController>().transform;
        
        switch (gameController.gameMode)
        {
            case GameController.GameMode.LoadGame: // Game Loaded
                FindObjectOfType<SaveManager>().LoadGame();
                break;
            
            case GameController.GameMode.NewGame: // New Game
                playerTransform.position = spawnPoints[0].position;
                break;
            
            case GameController.GameMode.GameMode: // Game Mode
                int spawnpointId = FindObjectOfType<SpawnPointSaver>().spawnpointId;

                playerTransform.position = spawnPoints[spawnpointId].position;
        
                FindObjectOfType<FadePanelManager>().SimpleFadeOut();
                break;
        }
    }
}
