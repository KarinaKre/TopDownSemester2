using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
 
    public StateInfo[] stateInfos; 
  //  public List<StateInfo> stateInfos;
  [SerializeField] TextMeshProUGUI text_header, text_description;
  [SerializeField] private GameObject stateContainer;
  [SerializeField] private Image image;
  
    private void OnEnable()
    {
        GameState.StateAdded += NewStateCollected;
    }


    private void OnDisable()
    {
        GameState.StateAdded -= NewStateCollected;
    }

    void NewStateCollected(string id ,int amount)
    {
        foreach (StateInfo stateInfo in stateInfos)
        {
            if (stateInfo.id == id)
            {
                text_header.SetText(stateInfo.name);
                text_description.SetText(stateInfo.description);
                image.sprite = stateInfo.sprite;
            }
        }
        
        print($"new Item collected with the id: {id} with the amount of");
        stateContainer.SetActive(true);
        
    }
}
