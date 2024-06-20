using System;
using System.Collections;
using System.Collections.Generic;
using ___WorkData.Movement;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{

    public enum ActionType{Watering,Attack,Default,Fishing}

    public ActionType actionType;
    
    private InputAction typeAction;
    private PlayerController playerController;
    public int actionId;
    public int weaponId;
    public Animator weaponAnim;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        PlayerController.SubscribeAction += Subscribe;
        PlayerController.UnsubscribeAction += Unsubscribe;
        
    }

    private void OnDisable()
    {
        PlayerController.UnsubscribeAction -= Unsubscribe;
        PlayerController.SubscribeAction -= Subscribe;
    }

    void Subscribe()
    {
        typeAction = GetComponent<PlayerController>()._inputActions.Player.Attack;
        typeAction.performed += Action;
    }

    void Unsubscribe()
    {
        typeAction.performed -= Action;
    }

    public void Action(InputAction.CallbackContext ctx)
    {
        switch (actionType)
        {
               
            
            case ActionType.Default:
                print("No ActionType declared");
                break;
            case ActionType.Watering:
                
                break;
            case ActionType.Attack:
                float dirX = 0;
                float dirY = 0;
                if (ctx.performed)
                {
                    print("action");
                   playerController._anim.SetTrigger("actionTrigger");
                   playerController._anim.SetInteger("actionId",actionId);
                  
                }

                dirX = playerController._anim.GetFloat("dirX");
                dirY = playerController._anim.GetFloat("dirY");
                weaponAnim.SetFloat("weaponId",0);
                weaponAnim.SetFloat("attackId",actionId);
                weaponAnim.SetTrigger("actionTrigger");
                weaponAnim.SetFloat("dirX",dirX);
                weaponAnim.SetFloat("dirY",dirY);
                
               
                break;
        }
    }
    
  
}
