using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DmgTrapBehaviour : MonoBehaviour
{
    public bool isInTrap;
    public float trapDamage = 0.5f;
    public float timer, time;
    public float health = 10f;
    private GameObject playerReference;


    //Trap Timer
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

    // in and out of the trap
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerReference = other.gameObject;
            isInTrap = true;
            GetDamage();
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
