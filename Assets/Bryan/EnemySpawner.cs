using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyGroup
{
    public GameObject enemyPrefab;
    public int count = 1;
}

[System.Serializable]
public class EnemyWave
{
    public EnemyGroup[] enemyGroups;
    public float spawnInterval = 1f;
}

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] waves;
    public Transform spawnPoint;
    public Transform targetBase;
    public float timeBetweenWaves = 5f;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < waves.Length)
        {
            EnemyWave wave = waves[currentWave];

            // Generar una lista con todos los prefabs de esta oleada
            List<GameObject> enemiesToSpawn = new List<GameObject>();
            foreach (EnemyGroup group in wave.enemyGroups)
            {
                for (int i = 0; i < group.count; i++)
                {
                    enemiesToSpawn.Add(group.enemyPrefab);
                }
            }

            // Mezclar la lista aleatoriamente
            Shuffle(enemiesToSpawn);

            // Spawnear los enemigos en el orden mezclado
            foreach (GameObject prefab in enemiesToSpawn)
            {
                SpawnEnemy(prefab);
                yield return new WaitForSeconds(wave.spawnInterval);
            }

            currentWave++;

            if (currentWave < waves.Length)
            {
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }

        Debug.Log("¡Todas las oleadas completadas!");
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        EnemyAI ai = newEnemy.GetComponent<EnemyAI>();
        if (ai != null)
        {
            ai.targetBase = targetBase;
        }
    }

    // Algoritmo de Fisher-Yates para mezclar una lista
    void Shuffle(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            GameObject temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
