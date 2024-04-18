using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChangeBehaviour : MonoBehaviour
{
    public Transform portPosition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = portPosition.position;
        }
       
    }
    
}
