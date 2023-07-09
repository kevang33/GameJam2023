using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperManager : MonoBehaviour
{
    // public Rigidbody2D rb; 
    public Transform playerPos;
    public GameObject helperPrefab;


    GameObject helperGameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Getting input for movement, trigger movement
    void Update()
    {
        // Spawn
        if (Input.GetKeyDown(KeyCode.P))
        {
            helperGameObject = Instantiate(helperPrefab, new Vector3(
                playerPos.position.x + Random.Range(-3f,3f), 
                playerPos.position.y + Random.Range(-3f,3f),
                0),
                playerPos.rotation);
        }
    }
}
