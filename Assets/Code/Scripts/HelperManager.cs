using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperManager : MonoBehaviour
{
    // public Rigidbody2D rb; 
    public Transform playerPos;
    public GameObject helperPrefab;

    [SerializeField] private float spawnTime = 8f;
    [SerializeField] private float maxHelpers = 15f;

    private float timeSinceLastSpawn;
    private float numHelpers = 0;


    GameObject helperGameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Getting input for movement, trigger movement
    void Update()
    {
        // // Spawn
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     helperGameObject = Instantiate(helperPrefab, new Vector3(
        //         playerPos.position.x + Random.Range(-3f,3f), 
        //         playerPos.position.y + Random.Range(-3f,3f),
        //         0),
        //         playerPos.rotation);
        // }

        // if (LevelManager.main.gameOver) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnTime && numHelpers < maxHelpers)
        {
            SpawnHelper();
            numHelpers++;
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnHelper()
    {
        helperGameObject = Instantiate(helperPrefab, new Vector3(
                playerPos.position.x + Random.Range(-3f,3f), 
                playerPos.position.y + Random.Range(-3f,3f),
                0),
                playerPos.rotation);
    }
}
