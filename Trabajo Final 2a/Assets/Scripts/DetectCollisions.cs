using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider otherTrigger)
    {
        if (otherTrigger.gameObject.CompareTag("Enemy"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject);
            gameManager.kills = gameManager.kills + 1;
        }

        if (otherTrigger.gameObject.CompareTag("Obstacle"))
        {
            Destroy(otherTrigger.gameObject);
            Destroy(gameObject);
        }
    }
}