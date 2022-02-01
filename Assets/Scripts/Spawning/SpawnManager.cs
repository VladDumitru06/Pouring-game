using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] ObjectPool _objectPool;
    [SerializeField] Transform _cupSpawnPosition;
    [SerializeField] SpawnBounds _spawnBounds;
    [SerializeField] bool _spawnCup = true;
    void FixedUpdate()
    {
        if (_spawnCup)
            SpawnCup();
    }
    private void SpawnCup()
    {
        if(_spawnBounds.canSpawn)
        {
            _objectPool.SpawnCup(_cupSpawnPosition.position);
        }
    }

}
