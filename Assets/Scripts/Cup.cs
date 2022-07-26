using Enums;
using UnityEngine;

public class Cup : MonoBehaviour
{
    #region Variables
    [SerializeField] public CupType cupType;
    [SerializeField] public int capacity;
    private bool _isMoving;
    private Vector2 _previousFrameVelocity;
    [SerializeField] public bool isMoving { get { return _isMoving; } }

    private Rigidbody2D _rigidBody2D;

    #endregion
    #region Events
    public delegate void Notify(GameObject gameObject);
    public event Notify OnCupTapped;
    #endregion
    #region Unity Methods
    private void Start()
    {
       _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        { Debug.Log("TAP"); OnCupTapped?.Invoke(gameObject); }
    }

    private void FixedUpdate()
    {
        if (_rigidBody2D.velocity == _previousFrameVelocity)
            _isMoving = false;
        else
            _isMoving = true;
        _previousFrameVelocity = _rigidBody2D.velocity;
    }
    #endregion
}
