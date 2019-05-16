using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{


    int enemyHealth = 100;
    Animator anim;
    Rigidbody2D rb;


    public float speedX;
    bool facingRight = true;
    public float distance;
    public Transform groundDetection;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    void Update()
    {
        animMoveEnemy(speedX); //player movement
        

        transform.Translate(Vector2.right * speedX * Time.deltaTime );

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if (facingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -200, 0);
                facingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
            }

        }
       

    }

    void animMoveEnemy(float enemySpeed)
    {
        // code player movement
        if (enemySpeed < 0  || enemySpeed > 0 )
        {
            anim.SetInteger("State", 2);
        }
        if (enemySpeed == 0 )
        {
            anim.SetInteger("State", 0);
        }

      //  rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }
}
