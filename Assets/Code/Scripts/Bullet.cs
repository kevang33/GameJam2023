using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;
    [SerializeField] private float bulletDuration = 2f;

    private Transform target;
    private Vector2 direction;
    private float fireTime;


    public void SetTarget(Transform _target)
    {
        target = _target;
        direction = (target.position - transform.position).normalized;
        fireTime = 0f;
    }

    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }
        if (fireTime > bulletDuration) {
            Destroy(gameObject);
            return;
        }
        fireTime += Time.deltaTime;
        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }

}