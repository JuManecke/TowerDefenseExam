using System;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private GameObject enemySpawn;
    [SerializeField] private ProgressManager progressManager;
    private Transform _targetPoint;
    private int _waypointIndex = 0;

    private void Awake()
    {
        if (enemySpawn == null)
        {
            enemySpawn = GameObject.Find("EnemySpawner");
        }
        if (progressManager == null)
        {
            progressManager = GameObject.Find("GameManager").GetComponent<ProgressManager>();
        }
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _targetPoint = enemySpawn.GetComponent<EnemySpawn>().waypointTransforms[0];
    }
    
    void Update()
    {
        if (Vector2.Distance(_targetPoint.position, transform.position) <= 0.1f)
        {
            if (_waypointIndex < enemySpawn.GetComponent<EnemySpawn>().waypointTransforms.Length - 1)
            {
                _waypointIndex++;
                _targetPoint = enemySpawn.GetComponent<EnemySpawn>().waypointTransforms[_waypointIndex];
            }
            else
            {
                progressManager._hasLost = true;
                Destroy(gameObject);
            }
        }
        else
        {
            _rigidbody.MovePosition(Vector2.MoveTowards(transform.position, _targetPoint.position, moveSpeed * Time.deltaTime));
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_targetPoint.position - transform.position).normalized;
        _rigidbody.velocity = direction * moveSpeed;
    }
}