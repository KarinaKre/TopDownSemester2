using System;
using System.Collections;
using System.Collections.Generic;
using ___WorkData.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
   private PlayerController playerController;
   private Player_InputActions _inputActions;
   private InputAction _farmAction;
   public Vector2 moveInput;
   public Animator _anim;
   
   public SpriteRenderer sr;
   public Sprite[] fieldSprites;
   private void Awake()
   {
      playerController = GetComponent<PlayerController>();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         sr.sprite = fieldSprites[1];
      }
   }
}
