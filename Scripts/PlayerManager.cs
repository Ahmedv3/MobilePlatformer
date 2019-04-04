using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float speedX;
    public float jumpSpeedY;

    bool facingRight, jumping, grounded;
    float speed;

    Animator anim;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(speed); //player movement
        Flip();

        // left player movement
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }
        // right player movement
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }
        // jump player movement
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded == true)
            {
                grounded = false;
                jumping = true;
                rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
                anim.SetInteger("State", 3);
            }
        }
    }

   void MovePlayer(float playerSpeed)
    {
        // code player movement
        if(playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping)
        {
            anim.SetInteger("State", 2);
        }
        if(playerSpeed == 0 && !jumping)
        {
            anim.SetInteger("State", 0);
        }

        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void Flip()
    {
        // code to flip player direction
        if(speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
            jumping = false;
            anim.SetInteger("State", 0);
        }
    }

    public void walkLeft()
    {
        speed = -speedX;
    }
    public void walkRight()
    {
        speed = speedX;
    }

    public void StopMovig()
    {
        speed = 0;
    }

    public void jump()
    {
        if(grounded == true)
        {
            grounded = false;
            jumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetInteger("State", 3);
        }
    }

}
