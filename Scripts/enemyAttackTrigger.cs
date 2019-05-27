using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackTrigger : MonoBehaviour
{
    private PlayerManager player;
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    public int dmg;

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.isTrigger != true && coll.CompareTag("Player"))
        {
            coll.SendMessageUpwards("Damage", dmg);
            if(player.jumpSpeedY > 0)
            {
                StartCoroutine(player.Knockback(0.02f, 20, player.transform.position));
            }
            
        }

    }
}
