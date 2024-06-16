using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public enum MoveDirection {idle = 0, left = -1, right = 1}
public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    Rigidbody2D rb;
    [SerializeField]
    float gravity;
    [SerializeField]
    float fastJumpForce;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float maxJumpForce;
    [SerializeField]
    float horizontalJumpForceWall;
    [SerializeField]
    float airMoveSpeed;
    [SerializeField]
    float groundMoveSpeed;
    [SerializeField]
    float slopeMoveSpeed;

    bool isClicked;
    public static bool isGrounded;
    bool jumped;
    bool jumpedStart;
    bool jumpedEnd;
    bool onTheWall;

    float timeStart;
    float totalJumpForce;
    float moveSpeed;
    public static float horizontalMove;



    private void Awake()
    {
        moveSpeed = groundMoveSpeed;
        isClicked = false;
        isGrounded = true;
        onTheWall = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;

        if (other.CompareTag("Ground"))
        {
            moveSpeed = groundMoveSpeed;
        }

        else if (other.CompareTag("Obstacle"))
        {
            transform.position = new Vector2(-7.5f, -2.9f);
        }

        else if (other.CompareTag("Slope"))
        {
            moveSpeed = slopeMoveSpeed;
        }

        else if (other.CompareTag("Goal"))
        {
            Debug.Log("You Won.");
        }

        if (other.CompareTag("Wall"))
        {
            rb.gravityScale = 1;
            onTheWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            isGrounded = false;
            rb.gravityScale = gravity;
            onTheWall = false;
        }
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        jumped = Input.GetKey(KeyCode.Space);
        jumpedStart = Input.GetKeyDown(KeyCode.Space);
        jumpedEnd = Input.GetKeyUp(KeyCode.Space);
    }

    private void Move(MoveDirection direction)
    {
        if (direction == MoveDirection.left)
            transform.localEulerAngles = new Vector3(0, 180, 0);
        else
            transform.localEulerAngles = new Vector3(0, 0, 0);

        transform.Translate(new Vector2((int)direction * horizontalMove, 0) * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (horizontalMove != 0)
        {
            if (horizontalMove < 0) Move(MoveDirection.left);

            else Move(MoveDirection.right);
        }

        if (jumpedStart && isGrounded)
        {
            timeStart = Time.time;
            isClicked = true;
            isGrounded = false;
            moveSpeed = airMoveSpeed;
        }

        else if (jumped && isClicked)
        {
            totalJumpForce = fastJumpForce + (Time.time - timeStart) * jumpForce;

            if (totalJumpForce >= maxJumpForce)
            {
                totalJumpForce = 0;
                isClicked = false;
            }

            rb.AddForce(new Vector2(0, totalJumpForce), ForceMode2D.Force);
            Debug.Log(onTheWall);

            if (onTheWall)
            {
                rb.AddForce(new Vector2(20, 0), ForceMode2D.Force);
            }
        }

        else if (jumpedEnd || isGrounded)
        {
            isClicked = false;
        }
    }
}
