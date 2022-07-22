using Enums;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] public CupType cupType;
    [SerializeField] public int capacity;
    public delegate void Notify();
    public event Notify OnCupTapped;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            OnCupTapped?.Invoke();
    }
 

}
