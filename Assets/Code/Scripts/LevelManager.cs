using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int gateHealth = 2;
    public bool gameOver = false;
    // Start is called before the first frame update
    private void Start()
    {
        main = this;
    }

    private void Update() {
        if (main.gateHealth == 0) {
            GameOver();
        }
    }
    
    private void GameOver() {
        Debug.Log("And that's game.");
        gameOver = true;
    }


}
