using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemySpawnTest
{
    public class SpawnEnemyTest
    {
        [UnityTest]
        public IEnumerator SpawnEnemy_EnemiesInstantiatedAtCorrectPosition()
        {
            GameObject enemySpawnGameObject = new GameObject();
            EnemySpawn enemySpawn = enemySpawnGameObject.AddComponent<EnemySpawn>();
            
            GameObject enemyPrefab = new GameObject();
            Transform[] waypointTransforms = new Transform[2];
            for (int i = 0; i < 2; i++)
            {
                GameObject waypoint = new GameObject();
                waypoint.transform.position = new Vector3(i, 0, 0);
                waypointTransforms[i] = waypoint.transform;
            }
            enemySpawn.enemyPrefab = enemyPrefab;
            enemySpawn.enemyPrefab.tag = "Enemy";
            enemySpawn.waypointTransforms = waypointTransforms;
            
            enemySpawn.SpawnEnemy();
            
            yield return null;
            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            Assert.IsNotNull(enemies, "No enemies instantiated.");
            Assert.Greater(enemies.Length, 0, "Incorrect number of enemies instantiated.");
            Assert.AreEqual(waypointTransforms[0].position, enemies[0].transform.position, "Enemy instantiated at incorrect position.");
            
            foreach (var enemy in enemies)
            {
                GameObject.DestroyImmediate(enemy);
            }
            GameObject.DestroyImmediate(enemySpawnGameObject);
        }
    }
}