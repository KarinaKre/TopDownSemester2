using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public bool isInTrap;
    public int trapDamage = 1;
    public float timer, time;
    public float health = 1f;
    private GameObject playerReference;
    public ColorSpriteSetter colorSpriteSetter;

    private void Update()
    {
        if(isInTrap)
        {
            timer -= Time.deltaTime;

            if(timer < 0 )
            {
                GetDamage();
                timer = time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerReference = other.gameObject;
            isInTrap = true;
            GetDamage();
        }
        if(other.CompareTag("axe"))//if a water Bullet hits the enemy it gets dmg
        {
            colorSpriteSetter.ColorObject();
            TakeDamage(1);
        }
      
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInTrap = false;
            timer = time;
        }
    }
  
    //Reference to the Health script, where the Heartsprites are stored and Merlin takes the dmg
    void GetDamage()
    {
        playerReference.gameObject.GetComponent<Health>().TakeDamage(trapDamage);
    }

    //Healthamount & taking Damage
    public void TakeDamage(float amount)
    {
        health -= 3;
       

        if (health <= 0)
        {
            health = 0;
          
            Destroy(gameObject);

        }
    }


}
