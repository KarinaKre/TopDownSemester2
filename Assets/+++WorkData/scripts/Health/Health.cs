using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;


    public float health, maxHealth;
    public Animator anim;

    public ColorSpriteSetter colorSpriteSetter;


    private void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(float amount)
    {
        colorSpriteSetter.ColorObject();
        health -= amount;
        OnPlayerDamaged?.Invoke();
     
        if (health <= 0)
        {
            health = 0;
            Debug.Log("You have died");
            OnPlayerDeath?.Invoke();
        }
    }

   

}
