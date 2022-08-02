using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBounds : MonoBehaviour
{

    [SerializeField] CupObjectPool _objectPool;
    /// <summary>
    /// false if it's despawner
    /// </summary>
    [SerializeField] private bool _isSpawner = true;
    /// <summary>
    /// Can a new cup be spawned
    /// </summary>
    public bool canSpawn = true;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isSpawner)
        { 
        if (collision.CompareTag("Cup"))
        {
                canSpawn = true;
        }
        }
    }
    /// <summary>
    /// if the script is for spawning, don't spawn when there's another cup, if it's for despawning, depspawn when you collide with another cup
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_isSpawner)
        {
            if (collision.CompareTag("Cup"))
            {
                canSpawn = false;
            }
        }
        if (!_isSpawner)
        {
            if (collision.CompareTag("Cup"))
            {
                _objectPool.RemoveCup(collision.gameObject);
            }
        }
    }
}
