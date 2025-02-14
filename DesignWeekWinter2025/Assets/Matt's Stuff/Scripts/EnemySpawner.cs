using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefabs;

    [SerializeField]
    private float _minimumSpawnTime = 3f;
    [SerializeField]
    private float _maximumSpawnTime = 6f;

    [SerializeField]
    private float _spawnDecreaseRate = 0.2f;
    [SerializeField]
    private float _minSpawnLimit = 0.5f;

    private float _timeUntilSpawn;
    private float _spawnIncreaseTimer = 0f;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        _spawnIncreaseTimer += Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilSpawn();
        }

        if (_spawnIncreaseTimer > 5f)
        {
            DecreaseSpawnRate();
            _spawnIncreaseTimer = 0f;
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    private void SpawnEnemy()
    {
        int enemyIDToSpawn = Random.Range(0, _enemyPrefabs.Length);
        Instantiate(_enemyPrefabs[enemyIDToSpawn], transform.position, Quaternion.identity);
    }

    private void DecreaseSpawnRate()
    {
        _minimumSpawnTime = Mathf.Max(_minimumSpawnTime - _spawnDecreaseRate, _minSpawnLimit);            // keeps spawn time above min limit but reduce gradually
        _maximumSpawnTime = Mathf.Max(_maximumSpawnTime - _spawnDecreaseRate, _minSpawnLimit + 1f);
    }

}
