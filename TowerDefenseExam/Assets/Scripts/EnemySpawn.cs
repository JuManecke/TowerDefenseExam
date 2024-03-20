using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] public Transform[] waypointTransforms;
    [SerializeField] private GameObject _enemyPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }
    
    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, this.transform.position, Quaternion.identity);
    }
}
