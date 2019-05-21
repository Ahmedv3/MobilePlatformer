using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{

    // Stats
    int enemyHealth;
    int maxEnemyHealth = 100;

    Animator anim;
    Rigidbody2D rb;


    bool hit;

    // moving stuff
    public float speedX;
    bool facingRight = true;
    public float distance;
    public Transform groundDetection;


   void Start()
    {
        enemyHealth = maxEnemyHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    void Update()
    {

        animMoveEnemy(speedX); 
               
        //player movement
        transform.Translate(Vector2.right * speedX * Time.deltaTime );

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if (facingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -170, 0);
                facingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
            }

        }

        if(enemyHealth <= 0)
        {
           // anim.SetInteger("State", 5);
           Destroy(gameObject);
           speedX = 0;

        }


    }

    void animMoveEnemy(float enemySpeed)
    {
        // code player movement
        if (enemySpeed < 0  || enemySpeed > 0 || hit == false)
        {
            anim.SetInteger("State", 2);
        }
        if (enemySpeed == 0 )
        {
            anim.SetInteger("State", 0);
        }
        if(hit == true)
        {
            anim.SetInteger("State", 4);
            hit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            anim.SetBool("damage", true);
        }

    }

    private void OnTriggerExit2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            anim.SetBool("damage", false);
        }

    }

    public void Damage(int damage)
    {
        hit = true;
        enemyHealth -= damage;
    }
}
