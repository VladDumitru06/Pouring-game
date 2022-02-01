using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeleterController : MonoBehaviour
{
    /// <summary>
    /// Is this particle deleter suppoused to follow the mouse?
    /// </summary>
    public bool follow = false;
    /// <summary>
    /// set lifetime to 0 on colision with water particle
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Metaball_liquid"))
        {
            collision.gameObject.GetComponent<MetaballParticleClass>().LifeTime = 0;

        }
    }
    /// <summary>
    /// If script is a follow script it will create a circle collider with a radius of 2.5f at the mouse position when right clicking
    /// </summary>
     void Update()
    {
        if (follow)
        { 
        if (Input.GetMouseButton(1) )
        {
            gameObject.GetComponent<CircleCollider2D>().radius = 2.5f;
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            gameObject.transform.position = pz;
        }
        else
        {

            gameObject.GetComponent<CircleCollider2D>().radius = 0;
        }
        }
    }

}
