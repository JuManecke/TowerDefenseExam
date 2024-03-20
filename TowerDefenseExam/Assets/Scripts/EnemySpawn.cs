using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] public Transform[] waypointTransforms;
    [SerializeField] private GameObject enemyPrefab;
    private bool _shouldSpawn = true;
    [SerializeField] [Range(.5f, 5f)] private float fixedSpawnRate;
    [SerializeField] private bool randomSpawnRate;

    private void Update()
    {
        if (_shouldSpawn && !randomSpawnRate)
        {
            Invoke("SpawnEnemy", fixedSpawnRate);
            _shouldSpawn = false;
        }
        else if (_shouldSpawn && randomSpawnRate)
        {
            float randomSpawnRate = UnityEngine.Random.Range(.5f, 5f);
            Invoke("SpawnEnemy", randomSpawnRate);
            _shouldSpawn = false;
        }
    }
    
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        _shouldSpawn = true;
    }
}
