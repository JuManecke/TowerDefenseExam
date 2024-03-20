using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private GameObject enemySpawn;
    [SerializeField] private GameObject progressManager;
    private Transform _targetpoint;
    private int _waypointIndex = 0;

    private void Awake()
    {
        if (enemySpawn == null)
        {
            enemySpawn = GameObject.Find("EnemySpawner");
        }
        if (progressManager == null)
        {
            progressManager = GameObject.Find("GameManager");
        }
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _targetpoint = enemySpawn.GetComponent<EnemySpawn>().waypointTransforms[0];
    }
    
    void Update()
    {
        if (Vector2.Distance(_targetpoint.position, transform.position) <= 0.1f)
        {
            if (_waypointIndex < enemySpawn.GetComponent<EnemySpawn>().waypointTransforms.Length - 1)
            {
                _waypointIndex++;
                _targetpoint = enemySpawn.GetComponent<EnemySpawn>().waypointTransforms[_waypointIndex];
            }
            else
            {
                progressManager.GetComponent<ProgressManager>()._hasLost = true;
                Destroy(gameObject);
            }
        }
        else
        {
            _rigidbody.MovePosition(Vector2.MoveTowards(transform.position, _targetpoint.position, moveSpeed * Time.deltaTime));
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_targetpoint.position - transform.position).normalized;
        
        _rigidbody.velocity = direction * moveSpeed;
    }
}