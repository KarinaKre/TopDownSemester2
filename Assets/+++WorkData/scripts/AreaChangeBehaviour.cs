using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChangeBehaviour : MonoBehaviour
{
    public Animator animDoor;
    public Transform portPosition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(InitiateTeleport(other));
        }
    }

    IEnumerator InitiateTeleport(Collider2D other)
    {
        animDoor.SetBool("fade",true);
        yield return new WaitForSeconds(0.3f);
        other.transform.position = portPosition.position;
        yield return new WaitForSeconds(.5f);
        animDoor.SetBool("fade",false);
    }
}
