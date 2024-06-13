using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private GameController gameController;
    private void OnEnable()
    {
        gameController = FindObjectOfType<GameController>();
        if (gameController.gameMode == GameController.GameMode.PreMenu)
        {
            gameController.gameMode = GameController.GameMode.MainMenu;
        }

        if (gameController.gameMode == GameController.GameMode.GameMode)
        {
            //...
        }
        
    }

    public void Button_NewGame()
    {
        gameController.gameMode = GameController.GameMode.NewGame;
        SceneManagers.LoadScene("Castle");
    }

    public void Button_Continue()
    {
        gameController.gameMode = GameController.GameMode.LoadGame;
        SceneManagers.LoadScene(PlayerPrefs.GetString("SceneName"));
    }

    public void Button_Quit()
    {
        Application.Quit();
    }
}
