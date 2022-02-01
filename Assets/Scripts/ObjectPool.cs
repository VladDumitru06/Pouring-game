using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    /// <summary>
    /// List of container objects
    /// </summary>
    [SerializeField]
    List<GameObject> _objects;
    /// <summary>
    /// List size of objects. Actual size is _listsize*_object.count
    /// </summary>
    [SerializeField]
    int _listSize = 20;
    /// <summary>
    /// List containing all the objects in the object pool
    /// </summary>
    List<GameObject> _cupList;
    /// <summary>
    /// Instantiates all the objects
    /// </summary>
    void Start()
    {
        _cupList = new List<GameObject>();
        for(int i = 0; i < _listSize; i++)
        {
            for (int j = 0; j < _objects.Count; j++)
            {
                GameObject _tempGO = Instantiate(_objects[j]);
                _tempGO.transform.parent = transform;
                _tempGO.SetActive(false);
                _cupList.Add(_tempGO);
            }
        }
    }
    /// <summary>
    /// Spawns a cup at given position, if no cup is available a new one is created and added to the list
    /// </summary>
    /// <param name="position">position to be spawned at</param>
    public void SpawnCup(Vector3 position)
    {
        int _tempIndex = isCupAvailable();
        if (_tempIndex != -1)
        {
            _cupList[_tempIndex].SetActive(true);
            _cupList[_tempIndex].transform.position = position;
        }
        else
        {
            //Creates a random object from the list of all available objects
            int _tempRnd = Random.Range(0, _objects.Count); ;
            GameObject _tempGO = Instantiate(_objects[_tempRnd]);
            _tempGO.transform.parent = transform;
            _tempGO.SetActive(true);
            _tempGO.transform.position = position; 
            _cupList.Add(_tempGO);
            _listSize++;
        }
    }
    /// <summary>
    /// Set a cup as inactive, doesn't destroy it
    /// </summary>
    /// <param name="cupToRemove"></param>
    public void RemoveCup(GameObject cupToRemove)
    {
        foreach(GameObject cup in _cupList)
        {
            if (cup == cupToRemove)
                cup.SetActive(false);
        }
    }
    /// <summary>
    /// Checks if there is an available cup to be spawned
    /// </summary>
    /// <returns>the index of the available cup or -1 if no cup is available</returns>
    private int isCupAvailable()
    {
        for (int i = 0; i < _listSize; i++)
        {
            if (_cupList[i].activeSelf == false)
            {
                return i;
            }
        }
        return -1;
    }
}
