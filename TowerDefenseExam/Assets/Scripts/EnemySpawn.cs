using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] public Transform[] waypointTransforms;
    [SerializeField] public GameObject enemyPrefab;
    private bool _shouldSpawn = true;
    [SerializeField] [Range(.5f, 5f)] public float fixedSpawnRate;
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
            float randomRate = UnityEngine.Random.Range(.5f, 5f);
            Invoke("SpawnEnemy", randomRate);
            _shouldSpawn = false;
        }
    }
    
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        _shouldSpawn = true;
    }
}