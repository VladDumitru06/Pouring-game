using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Water2D;
public class BeltController : MonoBehaviour
{

    bool water = false;
    /// <summary>
    /// Conveyor belt speed
    /// </summary>
    [SerializeField]
    float speed = 0f;
    SurfaceEffector2D _surfaceEffector;

    private float _lifeTime;
    private bool _inputKeySpace;
    private bool _inputKeyShift;
    void Start()
    {
        _lifeTime = Water2D_Spawner.instance.LifeTime;
        Water2D_Spawner.instance.LifeTime = 0;
        _surfaceEffector = GetComponent<SurfaceEffector2D>();
    }

    // Used for input for testing, CHANGE TO NEW INPUT SYSTEM!!!
    void Update()
    {
        if (Application.isEditor)
        { 
            _inputKeySpace = Input.GetKey(KeyCode.Space);
            _inputKeyShift = Input.GetKeyDown(KeyCode.LeftShift);

        }
        else
        {
            if(Input.touchCount == 1)
            _inputKeySpace = true;
            if(Input.touchCount > 1)
            _inputKeyShift = true;
        }
        if (_inputKeySpace)
        {
            if (_surfaceEffector.speed < speed)
                _surfaceEffector.speed += speed * Time.deltaTime;
        }
        else
            if (_surfaceEffector.speed > 0)
            _surfaceEffector.speed -= speed * Time.deltaTime;

        if (_inputKeyShift)
        {
            if (water == true)
            {
                Water2D_Spawner.instance.LifeTime = 0;
               // Water2D_Spawner.JustStopSpawner();
                water = false;

            }
            else
            {
                Water2D_Spawner.instance.LifeTime = _lifeTime;
               // Water2D_Spawner.RunSpawner();
                water = true;
            }
        }
       
    }
    /// <summary>
    /// If a water element colides with the conveyor belt
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Metaball_liquid"))
        {
            collision.gameObject.GetComponent<MetaballParticleClass>().LifeTime = 0;

        }
    }
}
