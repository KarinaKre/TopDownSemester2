using System;
using System.Collections;
using System.Collections.Generic;
using ___WorkData.Movement;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private PlayerController playerController; 
    public GameObject inventoryContainer;
    private Player_InputActions _inputActions;
    private InputAction _openInventory;

    #region EventFunctions
    
    private void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        playerController = FindObjectOfType<PlayerController>();
        _inputActions = new Player_InputActions();
        _openInventory = _inputActions.Player.Inventory;
    }

    private void OnEnable()
    {
        EnableInput();
        _openInventory.performed += OpenInventory;
    }

    private void OnDisable()
    {
        DisableInput();
        _openInventory.performed -= OpenInventory;
    }
    
    public void EnableInput()
    {
        _inputActions.Enable();
    }
    
    public void DisableInput()
    {
        _inputActions.Disable();
    }
    
  
    #endregion
    
    #region UIFunctions
    
    private void OpenInventory(InputAction.CallbackContext ctx)
    {
        inventoryContainer.SetActive(!inventoryContainer.activeSelf);
        
        if (inventoryContainer.activeSelf)
        {
            playerController.DisableInput();
            inventoryManager.RefreshInventory();
            
        }
        else
        {
            playerController.EnableInput();
        }
    }
    
    #endregion
}
