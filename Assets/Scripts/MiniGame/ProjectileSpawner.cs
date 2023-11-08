using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject pointPrefab;
    GameObject projectilePrefab;
    public bool gameOver;
    private float projPick;

    void Start()
    {
        SpawnProjectilesOverTime();
    }

    void SpawnProjectilesOverTime()
    {
        StartCoroutine(SpawnProjectilesOverTimeRoutine());

        IEnumerator SpawnProjectilesOverTimeRoutine()
        {
            while (!gameOver)
            {
                yield return new WaitForSeconds(1);

                // Randomly pick an obstacle or a point
                projPick = Random.Range(1, 50);
                if (projPick % 2f == 0)
                {
                    projectilePrefab = pointPrefab;
                }
                else
                {
                    projectilePrefab = obstaclePrefab;
                }

                // Spawn the selected projectile
                Instantiate(projectilePrefab, new Vector3(Random.Range(-9, 9), 6, 0), Quaternion.identity);
            }

            yield return null;
        }
    }
}
