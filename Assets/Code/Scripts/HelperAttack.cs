using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HelperAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject flash;

    [Header("Attribute")]
    [SerializeField] private float bps = 1f; //BulletsPerSecond

    private Transform mouseTransform;
    private float timeUntilFire;

    private void Start()
    {
        flash.SetActive(false);
        // Create a new empty GameObject to represent the mouse position
        GameObject mouseObject = new GameObject("MousePosition");
        mouseTransform = mouseObject.transform;
    }


    private void Update() {
        timeUntilFire += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if (timeUntilFire >= 1f / bps)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                mouseTransform.position = mousePosition;
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetFiringObjectTag(gameObject.tag);
        bulletScript.SetTarget(mouseTransform);

        // Show flash
        ShowFlash();
    }

    public void ShowFlash()
    {
        StartCoroutine(FlashEffect());
    }

    private System.Collections.IEnumerator FlashEffect()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        flash.SetActive(false);
    }
}