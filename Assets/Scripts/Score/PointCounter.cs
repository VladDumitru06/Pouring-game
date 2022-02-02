using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    /// <summary>
    /// Max number of water particles to give 100% of points
    /// </summary>
    [SerializeField] int _maxCount = 0;
    /// <summary>
    /// Max ammount of points the player can get for filling the respective container
    /// </summary>
    [SerializeField] int _points = 0;
    /// <summary>
    /// Number of particles that are filled in a glass
    /// </summary>
    int _count = 0;
    /// <summary>
    /// Error to notify that there is no maxCount and points set
    /// </summary>
    bool test = true;
    private void Update()
    {
        if (_maxCount <= 0 || _points <= 0)
            Debug.LogError(transform.parent.name + " doesn't have a maxCount or points set");
        if (_count >= _maxCount)
        { 
            Debug.Log("Player just recived: " + _points + " points");
            Debug.Log(_points + " " + transform);
            if (test == true)
            { 
            PointManager.ShowPoints(_points,transform);
                test = false;
            }
        }
    }
    /// <summary>
    /// When a particle enter the trigger set as the interior of the container. Increases points by one
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Metaball_liquid")&&_count < _maxCount)
        {
            _count++;
            PointManager.AddPoints(1);
        }
    }
    /// <summary>
    /// When a particle enter the trigger set as the interior of the container. Increases points by one
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Metaball_liquid"))
        {
            _count--;
            PointManager.RemovePoints(1);

        }
    }

}
