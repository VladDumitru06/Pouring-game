using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransferCupController : MonoBehaviour
{
    public delegate void Notify(GameObject gameObject);
    public event Notify CupFound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cup"))
        {
            CupFound?.Invoke(collision.gameObject);
        }
    }
}
