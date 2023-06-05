using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnAreaSize;
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 3.0f;
    public float margin = 10f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Generar posición aleatoria fuera del área de juego
            Vector2 randomPosition = GetRandomPositionOutsideArea();

            // Instanciar un nuevo enemigo en la posición aleatoria
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            // Esperar un intervalo de tiempo aleatorio antes de generar el siguiente enemigo
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector2 GetRandomPositionOutsideArea()
    {
        Vector2 randomPosition;

        int maxAttempts = 100;
        int currentAttempts = 0;

        do
        {
            // Generar una posición aleatoria dentro del área de juego
            randomPosition = new Vector2(
                Random.Range(transform.position.x - spawnAreaSize.x - margin, transform.position.x + spawnAreaSize.x + margin),
                Random.Range(transform.position.x - spawnAreaSize.y - margin, transform.position.x + spawnAreaSize.y + margin)
            );

            currentAttempts++;

            if (currentAttempts >= maxAttempts)
            {
                Debug.LogWarning("No se pudo encontrar una posición fuera del área de spawn después de " + maxAttempts + " intentos. Se utilizará la posición generada dentro del área.");
                break;
            }

        } while (IsInsideSpawnArea(randomPosition));

        return randomPosition;
    }

    private bool IsInsideSpawnArea(Vector2 position)
    {
        // Verificar si la posición está dentro del área de juego
        return position.x >= transform.position.x - spawnAreaSize.x &&
               position.x <= transform.position.x + spawnAreaSize.x &&
               position.y >= transform.position.y - spawnAreaSize.y &&
               position.y <= transform.position.y - spawnAreaSize.y;
    }
}

