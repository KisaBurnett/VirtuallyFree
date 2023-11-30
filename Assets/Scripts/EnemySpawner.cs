using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    CombatScore plyrHp;

    GameObject hpTracker;
    
    int current = 0;
    int enemiesPerWave;
    int pick;
    int previous = 0;
    int waves;

    // Start is called before the first frame update
    void Start()
    {
        hpTracker = GameObject.FindWithTag("Score");
        plyrHp = hpTracker.GetComponent<CombatScore>();
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (PlayerStats.Instance.level <= 2)
        {
            waves = 2;
            enemiesPerWave = 1;
        }
        else if((PlayerStats.Instance.level > 2) && (PlayerStats.Instance.level <= 5))
        {
            waves = 2;
            enemiesPerWave = 2;
        }
        else if(PlayerStats.Instance.level > 5)
        {
            waves = 3;
            enemiesPerWave = 3;
        }

        plyrHp.enemiesToKill = waves * enemiesPerWave;

        StartCoroutine(SpawnProjectilesOverTimeRoutine());
    }

    IEnumerator SpawnProjectilesOverTimeRoutine()
    {
        if (PlayerStats.Instance.completedHuntTutorial == false)
        {
            yield return new WaitForSeconds(5);
        }

        for (int i = 0; i < waves; i++)
        {
            for (int j = 0; j < enemiesPerWave; j++)
            {
                while ((current >= (previous - 2)) & (current <= (previous + 2)))
                {
                    current = Random.Range(-9, 9);
                }

                // Spawn the enemy, depending on player level
                if (PlayerStats.Instance.level < 5)
                {
                    Instantiate(enemy1, new Vector3(current, 4, 0), Quaternion.identity);
                    yield return new WaitForSeconds(2);
                }
                else if (PlayerStats.Instance.level < 10)
                {
                    pick = Random.Range(1, 3);

                    if (pick < 2)
                    {
                        Instantiate(enemy1, new Vector3(current, 4, 0), Quaternion.identity);
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        Instantiate(enemy2, new Vector3(current, 4, 0), Quaternion.identity);
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    pick = Random.Range(1, 4);

                    if ((pick >= 1) && (pick < 2))
                    {
                        Instantiate(enemy1, new Vector3(current, 4, 0), Quaternion.identity);
                        yield return new WaitForSeconds(2);
                    }
                    else if ((pick >= 2) && (pick < 3))
                    {
                        Instantiate(enemy2, new Vector3(current, 4, 0), Quaternion.identity);
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        Instantiate(enemy3, new Vector3(current, 4, 0), Quaternion.identity);
                        yield return new WaitForSeconds(10);
                    }
                }

                previous = current;
            }

            yield return new WaitForSeconds(10);
        }

        yield return null;
    }
}
