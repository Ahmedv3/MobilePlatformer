using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Stats
    bool playerHit;
    public int playerHealth;
    int maxHealth = 5;


    public GameObject coinParticle;

    

    // moving 'n jumping stuff 
    bool facingRight, jumping, grounded;
    float speed;
    public float speedX;
    public float jumpSpeedY;

    Animator anim;
    Animator anim2;
    Rigidbody2D rb;

    private gameMaster GM;

    // Start is called before the first frame update
    void Start()
    {

        playerHit = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;


        playerHealth = maxHealth;

        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        
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
               
            }
        }

        if(playerHealth <= 0)
        {
            Die();
        }

    }

    void MovePlayer(float playerSpeed)
    {
        // code player movement
        if (playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping)
        {
            anim.SetInteger("State", 2);
        }
        if (playerSpeed == 0 && !jumping )
        {
            anim.SetInteger("State", 0);
        }
        if (playerHit == true)
        {
            anim.SetInteger("State", 4);
            playerHit = false;
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
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
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

    public void knockup()
    {
        rb.AddForce(new Vector2(rb.velocity.x, 450));
    }

    void Die()
    {
        //restart
       // SceneManager.LoadScene("GameScene");
    }


    public void Damage(int damage)
    {
        playerHit = true;
        playerHealth -= damage;
    }

    public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection)
    {
        float timer = 0;
        while (knockDuration > timer)
        {
            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockDirection.x * -100, knockDirection.y * knockPower, transform.position.z));
        }

        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Instantiate(coinParticle, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            gameMaster.instance.changeScore();
        }

        if (collision.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            heartUP.instance.heartOneUP();
        }
    }

    

}
