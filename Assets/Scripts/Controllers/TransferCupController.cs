using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransferCupController : MonoBehaviour
{
    public delegate void Notify(GameObject gameObject);
    public event Notify CupFound;
    public event Notify CupLost;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cup"))
        {
            CupFound?.Invoke(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cup"))
        {
            CupLost?.Invoke(other.gameObject);
        }
    }
}
