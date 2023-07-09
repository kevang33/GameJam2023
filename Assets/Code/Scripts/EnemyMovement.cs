using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Rigidbody2D rb; 
    
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    // Next position enemy should move towards
    private Transform target;
    // Index along path enemy moving towards
    private int pathIndex = 0;

    void Start() {
        // Initial target is start point
        target = LevelManager.main.path[pathIndex];
    }

    void Update() {
        // If enemy position is near target, update target to be next point on path
        if(Vector2.Distance(target.position, transform.position) <= 0.1f){
            pathIndex++;

            // Once enemy reaches end, destroy enemy
            if(pathIndex == LevelManager.main.path.Length){
                EnemySpawner.onEnemyDestroy.Invoke();
                LevelManager.main.gateHealth--;
                Destroy(gameObject);
                return;
            } else {
                target = LevelManager.main.path[pathIndex];
            }

        }
    }

    private void FixedUpdate() {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction*moveSpeed;
    }

}