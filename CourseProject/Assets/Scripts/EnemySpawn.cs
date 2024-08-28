using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject targetPlayer;
    [SerializeField] Vector2 spawnPositionArea;
    [SerializeField] float spawnCooldown;
    float spawnTimer;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer < 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnCooldown;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            UnityEngine.Random.Range(-spawnPositionArea.x, spawnPositionArea.x),
            UnityEngine.Random.Range(-spawnPositionArea.y, spawnPositionArea.y),
            - 1f);

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.GetComponent<Enemy>().SetTarget(targetPlayer);

        newEnemy.transform.position = spawnPosition;
    }
}
