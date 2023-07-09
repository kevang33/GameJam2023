using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyAttack : MonoBehaviour {
    [Header("References")]
    [SerializeField] private LayerMask turretsMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float bps = 1f; //BulletsPerSecond

    private Transform target;
    private float timeUntilFire;


    private void Update() {
        if(target == null){
            FindTarget();
            return;
        }

        // RotateTowardsTarget();

        if (!CheckTargetIsInRange()){
            target = null;
        } else {
            timeUntilFire += Time.deltaTime;
            if(timeUntilFire >= 1f / bps){
                Shoot();
                timeUntilFire = 0f;
            }

        }
    } 

    private void FindTarget(){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, turretsMask);

        if (hits.Length > 0){
            target = hits[0].transform;
        }
    }

    private void Shoot(){
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetFiringObjectTag(gameObject.tag);
        bulletScript.SetTarget(target);
    }

    private bool CheckTargetIsInRange(){
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    // private void RotateTowardsTarget(){
    //     float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

    //     Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
    //     turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    // }

    // Makes range circle
    private void OnDrawGizmosSelected() {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

}