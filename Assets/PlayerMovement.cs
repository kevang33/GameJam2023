using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float flashTime = 0.3f;

    public Rigidbody2D rb;
    public Camera cam;
    public GameObject flash;

    Vector2 movement;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);  
    }

    // Getting input for movement, trigger movement
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Moving player based on input
    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);    

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    public void showFlash()
    {
        Debug.Log("Shoot");
        flash.SetActive(true);
        // delay(flashTime);
        Invoke("HideObject", flashTime);
        
        Debug.Log("Over");


    }

    private void HideObject() 
    {
        flash.SetActive(false);
    }
}
