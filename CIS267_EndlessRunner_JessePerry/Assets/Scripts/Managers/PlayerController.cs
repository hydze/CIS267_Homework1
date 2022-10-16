using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private static Rigidbody2D playerRigidBody;
    private float inputHorizontal;
    public float jumpForce;
    private bool isGrounded;
    private static bool isGravity;
   // private static int gravityDelay;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Time.timeScale = 1;
        //gravityDelay = 7;

        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movePlayerLateral();
        jump();

       if (isGravity)
        {
            reverseJump();
            flipPlayerGrav();
            Invoke("revertGravity", 5);
        }
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

    private void reverseJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            playerRigidBody.velocity = Vector2.down * jumpForce;
        }
    }

    public static void inverseGravity()
    {
        isGravity = true;
        playerRigidBody.gravityScale = -7f;
    }

    private void flipPlayerGrav()
    {
        transform.rotation = Quaternion.Euler(180, 0, 0);
    }

    private void revertGravity()
    {
        isGravity = false;
        playerRigidBody.gravityScale = 7f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //transform.rotation = new Quaternion().;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Border"))
        {
            if(HeartControl.health == 3)
            {
                HeartControl.health--;
                HeartControl.health--;
                HeartControl.health--;
            }
            if (HeartControl.health == 2)
            {
                HeartControl.health--;
                HeartControl.health--;
            }
            if (HeartControl.health == 1)
            {
                HeartControl.health--;
            }

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
