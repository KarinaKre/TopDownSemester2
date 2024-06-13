using System.Collections;
using System.Collections.Generic;
using ___WorkData.Movement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public void SaveGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("SceneName",currentScene.name);
        
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;
        PlayerPrefs.SetFloat("PlayerPosX",playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY",playerTransform.position.y);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY"))
        {
            Transform playerTransform = FindObjectOfType<PlayerController>().transform;
            float posX = PlayerPrefs.GetFloat("PlayerPosX");
            float posY = PlayerPrefs.GetFloat("PlayerPosY");
            playerTransform.position = new Vector3(posX, posY, 0);
        }
   
    }
}
