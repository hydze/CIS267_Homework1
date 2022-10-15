using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private static Rigidbody2D playerRigidBody;
    private float inputHorizontal;
    public float jumpForce;
    private bool isGrounded;
    public float timeBetweenSpawn;
    public float spawnTime;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        Time.timeScale = 1;
    }

    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);

        flipPlayer(inputHorizontal);
    }

    private void flipPlayer(float input)
    {
        if (input > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (input < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            playerRigidBody.velocity = Vector2.up * jumpForce;
        }
    }

    public static void inverseGravity()
    {
        
        if (Time.time > spawnTime)
        {
            playerRigidBody.gravityScale = -7f;
            spawnTime = Time.time + timeBetweenSpawn;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }
}
