using System;
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
    private string firingObjectTag;


    public void SetTarget(Transform _target)
    {
        target = _target;
        direction = (target.position - transform.position).normalized;
        fireTime = 0f;
    }

    public void SetFiringObjectTag(string _firingObjectTag)
    {
        firingObjectTag = _firingObjectTag;
        if (String.Compare(firingObjectTag, "Player") == 0 || String.Compare(firingObjectTag, "Enemy") == 0)
        {
            gameObject.layer = LayerMask.NameToLayer("EnemyBullet");
        }
        else if (String.Compare(firingObjectTag, "Turret") == 0)
        {
            gameObject.layer = LayerMask.NameToLayer("TurretBullet");
        }
    }

    public void SetBulletSpeed(float _bulletSpeed)
    {
        bulletSpeed = _bulletSpeed;
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
        if (other.gameObject.CompareTag(firingObjectTag)) return; // No friendly fire

        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }

}