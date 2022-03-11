using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColisionsEnemy : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider otherTrigger)
    {
        if (otherTrigger.gameObject.CompareTag("Player"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject);
        }

        if (otherTrigger.gameObject.CompareTag("Obstacle"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject);
        }
    }
}