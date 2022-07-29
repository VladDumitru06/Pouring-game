using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// List of container objects available, used for populating object pool
    /// </summary>
    [SerializeField]
    List<GameObject> _objects;
    /// <summary>
    /// List size of objects. Actual size is _listsize*_objects.count
    /// </summary>
    [SerializeField]
    int _listSize = 20;
    /// <summary>
    /// List containing all the objects in the object pool
    /// </summary>
    [SerializeField]
    List<Cup> _cupList;
    /// <summary>
    /// Instantiates all the objects
    /// </summary>
    #endregion
    #region Unity Methods
    void Awake()
    {
        PopulatePool();
    }
    #endregion
    #region Methods
    /// <summary>
    /// Populates the object pool with _listsize*_objects.count objects
    /// </summary>
    private void PopulatePool()
    {
        _cupList = new List<Cup>();
        for (int i = 0; i < _listSize; i++)
        {
            for (int j = 0; j < _objects.Count; j++)
            {
                GameObject _TempGO = Instantiate(_objects[j].gameObject);
                _TempGO.gameObject.transform.parent = transform;
                _TempGO.gameObject.SetActive(false);
                _cupList.Add(_TempGO.GetComponent<Cup>());
            }
        }
    }
    /// <summary>
    /// Spawns a cup at given position, if no cup is available a new one is created and added to the list and spawned at the position
    /// </summary>
    /// <param name="position">position to be spawned at</param>
    public void SpawnCup(Vector3 position, CupType _cupType)
    {
        int _tempIndex = isCupAvailable(_cupType);
        Debug.Log("TEMPINDEX " + _tempIndex);
        if (_tempIndex != -1)
        {
            _cupList[_tempIndex].gameObject.SetActive(true);
            _cupList[_tempIndex].cupStatus = CupStatus.Making;
            float halfHeight = _cupList[_tempIndex].gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2;
            _cupList[_tempIndex].gameObject.transform.position = new Vector3(position.x,position.y + halfHeight);
        }
        else
        {
            GameObject _TempGO = Instantiate(GetCupByType(_cupType).gameObject);
            _TempGO.gameObject.transform.parent = transform;
            _TempGO.gameObject.SetActive(true);
            _TempGO.gameObject.transform.position = position;
            _TempGO.GetComponent<Cup>().cupStatus = CupStatus.Making;
            _cupList.Add(_TempGO.GetComponent<Cup>());
            _listSize++;
        }
    }
    /// <summary>
    /// Set a cup as inactive, doesn't destroy it
    /// </summary>
    /// <param name="cupToRemove"></param>
    public void RemoveCup(GameObject cupToRemove)
    {
        foreach(Cup cup in _cupList)
        {
            if (cup.gameObject == cupToRemove)
            {
                cup.cupStatus = CupStatus.Despawned;
                cup.gameObject.SetActive(false); 
            }
        }
    }
    /// <summary>
    /// Checks if there is an available cup to be spawned
    /// </summary>
    /// <returns>the index of the available cup or -1 if no cup is available</returns>
    private int isCupAvailable(CupType _cupType)
    {
        Debug.Log("isCupAvailable" + _cupList.Count);
        for (int i = 0; i < _cupList.Count; i++)
        {
            Debug.Log(_cupList[i].gameObject.activeSelf + " " + _cupList[i].cupType);
            if (_cupList[i].gameObject.activeSelf == false && _cupList[i].cupType == _cupType)
            {
                return i;
            }
        }
        return -1;
    }
    private Cup GetCupByType(CupType type)
    {
        foreach (GameObject x in _objects)
        {
            Cup _tempCup = x.GetComponent<Cup>();
            Debug.Log("tempCUP");
            if (_tempCup.cupType == type)
                return _tempCup;
        }
        return null;
    }
    #endregion
}
