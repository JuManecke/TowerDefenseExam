using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLogic : MonoBehaviour
{
    public bool isActive = false;
    private float _fireCooldown = 3f;
    [SerializeField] private GameObject _projectile;

    private void Update()
    {
        if (isActive)
        {
            Firing();
            Invoke("FiringCooldown", _fireCooldown);
        }
    }
    
    void Firing()
    {
        isActive = false;
        Vector3 spawnPosition = this.transform.position;
        Instantiate(_projectile, new Vector3(spawnPosition.x, spawnPosition.y + .5f, -.02f), Quaternion.identity);
    }
    void FiringCooldown()
    {
        isActive = true;
    }
}
