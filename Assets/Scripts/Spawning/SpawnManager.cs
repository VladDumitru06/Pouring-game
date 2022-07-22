using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] ObjectPool _objectPool;
    [SerializeField] Transform _cupSpawnPosition;
    [SerializeField] SpawnBounds _spawnBounds;
    [SerializeField] bool _spawnCup = true;

    public void SpawnCup(CupType _cupType)
    {
        if(_spawnBounds.canSpawn)
        {
            _objectPool.SpawnCup(_cupSpawnPosition.position,_cupType);
        }
    }

}
