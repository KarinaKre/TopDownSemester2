using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
   [SerializeField] private InventorySlot[] inventorySlots;
   [SerializeField] private GameObject inventoryContainer;
   private GameState gameState;
   private StateManager stateManager;
   private void Awake()
   {
      gameState = FindObjectOfType<GameState>();
      stateManager = FindObjectOfType<StateManager>();
   }

   void RefreshInventory()
   {
      
   }

   public void OpenInventory()
   {
      List<State> currentStateList = gameState.GetStateList();

      for (int i = 0; i < inventorySlots.Length; i++)
      {
         if (i > currentStateList.Count -1)
         {
            
         }
         else
         {
            StateInfo newStateInfo = stateManager.GetStateById(currentStateList[i].id);
            inventorySlots[i].SetInventorySlot(newStateInfo.sprite,currentStateList[i].amount);
         }
      }
   }
   
   public void CloseInventory()
   {
      
   }
}
