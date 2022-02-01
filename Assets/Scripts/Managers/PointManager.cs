using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointManager
{
    public delegate void OnPointsAdded(int points);
    public static event OnPointsAdded onPointsAdded;
    public delegate void OnPointsRemoved(int points);
    public static event OnPointsRemoved onPointsRemoved;
    public static void AddPoints(int points)
    {
        onPointsAdded.Invoke(points);
    }
    public static void RemovePoints(int points)
    {
        onPointsRemoved.Invoke(points);
    }

}
