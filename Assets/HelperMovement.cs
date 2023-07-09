using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperMovement : MonoBehaviour
{

    // private float currSpeed = 0;
    public float helperSpeed = 5f;
    // public float helperAcceleration = 0.5f;
    // public float flashTime = 0.3f;

    // public Rigidbody2D rb; 
    public Camera cam;
    public Transform playerPos;
    // public GameObject flash;

    Vector2 moveDir;
    Vector2 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        // flash.SetActive(false);  

        // When new helper spawns, find camera and transform
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Getting input for movement, trigger movement
    void Update()
    {
        // currSpeed += Mathf.Min(helperAcceleration * Time.deltaTime, 1);    // limit to 1 for "full speed"
        // Vector3 pos = Vector3.MoveTowards(transform.position, playerPos.position, speed * currSpeed * Time.deltaTime);

        // GetComponent<Rigidbody2D>().MovePosition(pos);

        moveDir =  playerPos.position - transform.position;
        

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        

    }

    void FixedUpdate()
    {
        // Change angle
        Vector2 lookDir = mousePos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().rotation = angle;

        // Change Motion
        Vector3 moveVec = new Vector3(moveDir.x, moveDir.y, 0);
        transform.position += (moveVec * helperSpeed) * Time.deltaTime;

    }

    // Moving player based on input
    // void FixedUpdate() 
    // {
    //     // Debug.Log("x " + moveDir.x.ToString());
    //     // Debug.Log("y " + moveDir.y.ToString());
    //     Rigidbody2D rb = GetComponent<Rigidbody2D>();
    //     // rb.MovePosition(rb.position + moveDir * helperMoveSpeed * Time.fixedDeltaTime);    
    //     // transform.position += moveDir * helperMoveSpeed * Time.fixedDeltaTime;

    //     Vector2 lookDir = mousePos - rb.position;
    //     float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
    //     rb.rotation = angle;
    // }

    // public void showFlash()
    // {
    //     flash.SetActive(true);
    //     Invoke("HideObject", flashTime);
    // }

    // private void HideObject() 
    // {
    //     flash.SetActive(false);
    // }
}
