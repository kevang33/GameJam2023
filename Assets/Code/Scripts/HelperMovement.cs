using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform playerPos;
    public Rigidbody2D rb;
    public float helperSpeed = 5f;

    Vector2 moveDir;
    Vector2 mousePosition;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        moveDir = playerPos.position - transform.position;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        // Look at the mouse position
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        Vector3 moveVec = new Vector3(moveDir.x, moveDir.y, 0);
        transform.position += (moveVec * helperSpeed) * Time.deltaTime;
    }
}
