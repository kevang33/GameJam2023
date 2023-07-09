using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible) 
        {
            Destroy(gameObject);
        }
    }

    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        // collision
    }
}
