using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// This value needs to be saved as score
    /// </summary>
    private int _points = 0;
    private void Start()
    {
        PointManager.onPointsAdded += AddPoints;
        PointManager.onPointsRemoved += RemovePoints;
    }
    public void AddPoints(int points)
    {
        _points += points;
    }
    public void RemovePoints(int points)
    {
        _points -= points;
    }

}
