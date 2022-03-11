using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject enemyPrefab;

    private float spawnRate = 3f;
    private float startDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnRandomTarget");
    }

    // Update is called once per frame
    void Update()
    {
        // Invoca repetidamente la función spawnRandomTarget
        InvokeRepeating("spawnRandomTarget", startDelay, spawnRate);
    }

    // Controlador de spawnear los obstáculos
    private IEnumerator spawnRandomTarget()
    {
        // while (!gameOver)
        // {
        // Cada 3s se spawnea un obstáculo
        yield return new WaitForSeconds(spawnRate);

        // Instancia los obstáculos
        Instantiate(enemyPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
        // }
    }
}
