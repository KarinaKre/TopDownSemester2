using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    
    private DmgTrapBehaviour dmgTrapBehaviour;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DmgTrapBehaviour enemy = other.GetComponent<DmgTrapBehaviour>();
            Destroy(gameObject);
            
            if (enemy != null)
            {
                enemy.TakeDamage(-1);
            }
        }
    }
}
