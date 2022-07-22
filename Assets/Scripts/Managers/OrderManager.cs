using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OrderManager : MonoBehaviour
{
    [SerializeField] List<Order> _orderList;
    [SerializeField] float _spawnTime;
    [SerializeField] SpawnManager _spawnManager;
    [SerializeField] Transform _sellPosition;
    [SerializeField] ScoreManager _scoreManager;
    private void Start()
    {
        AddData();
        StartCoroutine(SpawnOrder(_spawnTime));
    }
    void AddData()
    {
        _orderList = new List<Order>();
        Order _tempOrder = new Order(CupType.CoffeeCup, OrderStatus.Waiting, 50, 20);
        _orderList.Add(_tempOrder);
         _tempOrder = new Order(CupType.Bottle, OrderStatus.Waiting, 100, 25);
        _orderList.Add(_tempOrder);
         _tempOrder = new Order(CupType.CoffeeCup, OrderStatus.Waiting, 35, 20);
        _orderList.Add(_tempOrder);
         _tempOrder = new Order(CupType.Bottle, OrderStatus.Waiting, 50, 20);
        _orderList.Add(_tempOrder);
         _tempOrder = new Order(CupType.CoffeeCup, OrderStatus.Waiting, 50, 20);
        _orderList.Add(_tempOrder);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopAllCoroutines();
        }
    }
  

    IEnumerator SpawnOrder(float difficulty)
    {
        if (_orderList.Count <= 0)
            StopAllCoroutines();
        else
        { 
        //_spawnManager.SpawnCup(_orderList[0].cupType);
        foreach(Order x in _orderList)
        {
            if (x.orderStatus == OrderStatus.Waiting)
            {
                _spawnManager.SpawnCup(x.cupType);
                Debug.Log("New Order:\nCupType: " + x.cupType + " Amount: " + x.capacity);
                x.orderStatus = OrderStatus.Making;
                yield return new WaitForSeconds(difficulty);
            }
        }
        }
    }
    void FinishOrder(Order _orderToSell)
    {

    }
}
