using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public int waves;
    public int enemiesPerWave;

    int previous = 0;
    int current = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        StartCoroutine(SpawnProjectilesOverTimeRoutine());

        IEnumerator SpawnProjectilesOverTimeRoutine()
        {
            for (int i = 0; i < waves; i++)
            {
                for(int j = 0; j < enemiesPerWave; j++)
                {
                    while ((current >= (previous - 2)) & (current <= (previous + 2)))
                    {
                        current = Random.Range(-9, 9);
                    }

                    yield return new WaitForSeconds(2);

                    // Spawn the enemy
                    Instantiate(enemy1, new Vector3(current, 4, 0), Quaternion.identity);

                    previous = current;
                }

                yield return new WaitForSeconds(10);
            }

            yield return null;
        }
    }
}
