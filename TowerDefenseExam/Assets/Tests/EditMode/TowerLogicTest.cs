using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TowerLogicTest
{
    public class TowerFiringTest
    {
        [UnityTest]
        public IEnumerator TowerFiringTestWithEnumeratorPasses()
        {
            GameObject towerGameObject = new GameObject();
            TowerLogic towerLogic = towerGameObject.AddComponent<TowerLogic>();
            towerLogic.isActive = true;
            
            GameObject projectilePrefab = new GameObject();
            projectilePrefab.tag = "Projectile";
            towerLogic._projectile = projectilePrefab;
            
            towerLogic.Firing();
            
            yield return new WaitForSeconds(towerLogic._fireCooldown + 0.2f);
            
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
            
            Assert.Greater(projectiles.Length, 0, "No projectile instantiated.");
            
            foreach (var projectile in projectiles)
            {
                GameObject.Destroy(projectile);
            }
            GameObject.Destroy(towerGameObject);
        }

    }
}