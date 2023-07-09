using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerShoot : MonoBehaviour
{

    public Transform firingPoint;
    public GameObject bulletPrefab;

    public GameObject flash;

    [SerializeField] private Camera cam;
    [SerializeField] private float bps = 3f; //BulletsPerSecond

    private Transform mouseTransform;
    [SerializeField] private float bulletSpeed = 10f;
    private float timeUntilFire;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        // Create a new empty GameObject to represent the mouse position
        GameObject mouseObject = new GameObject("MousePosition");
        mouseTransform = mouseObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilFire += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            if (timeUntilFire >= 1f / bps)
            {
                Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                mouseTransform.position = mousePosition;
                timeUntilFire = 0f;

                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetFiringObjectTag(gameObject.tag);
        bulletScript.SetBulletSpeed(bulletSpeed);
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
