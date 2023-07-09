using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public int gateHealth = 2;
    public bool gameOver = false;
    // Start is called before the first frame update
    private void Start()
    {
        main = this;
    }

    private void Update() {
        if (gameOver == true) {
            GameOver();
        }
    }
    
    private void GameOver() {
        Debug.Log("And that's game.");
        gameOver = false;
        SceneManager.LoadScene(0);

    }


}
