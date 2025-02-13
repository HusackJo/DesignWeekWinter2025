using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenesscController : MonoBehaviour
{
    public bool AwareOfPlayer {  get; private set; }
    public Vector2 DirectionToPlayer {  get; private set; }

    [SerializeField]
    private float _PlayerAwarenessDistance;
    private Transform _player;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _PlayerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
