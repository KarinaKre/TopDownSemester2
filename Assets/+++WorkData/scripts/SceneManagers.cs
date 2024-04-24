using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{

    public string LoadScenes;
    public static void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(LoadScenes);
        }
    }

   
}
