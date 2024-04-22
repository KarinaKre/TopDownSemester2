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
        animDoor.Play("Panel_fade_in");
        yield return new WaitForSeconds(3);
        other.transform.position = portPosition.position;
        yield return new WaitForSeconds(.5f);
        animDoor.Play("Panel_fade_out");
    }
}
