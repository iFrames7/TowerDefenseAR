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
    private bool isSpawning = false;

    public void ActivateSpawner()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnWaves());
        }
    }

    public void DeactivateSpawner()
    {
        StopAllCoroutines();
        isSpawning = false;
    }

    IEnumerator SpawnWaves()
    {
        while (currentWave < waves.Length)
        {
            EnemyWave wave = waves[currentWave];

            List<GameObject> enemiesToSpawn = new List<GameObject>();
            foreach (EnemyGroup group in wave.enemyGroups)
            {
                for (int i = 0; i < group.count; i++)
                {
                    enemiesToSpawn.Add(group.enemyPrefab);
                }
            }

            Shuffle(enemiesToSpawn);

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

        Debug.Log("Â¡Todas las oleadas completadas!");
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
