using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomBlackout : MonoBehaviour
{
 public GameObject blackOut;
 public GameObject blackIn;
 

 private void OnTriggerEnter2D(Collider2D other)
 {
  if (other.CompareTag("Player"))
  {
   blackOut.SetActive(false);
   blackIn.SetActive(true);
   
  }
 }
 
}
