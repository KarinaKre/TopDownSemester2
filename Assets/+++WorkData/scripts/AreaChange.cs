using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaChange : MonoBehaviour
{

    public Animator anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("fade",true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
