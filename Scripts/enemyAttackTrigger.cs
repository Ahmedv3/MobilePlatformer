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
            StartCoroutine(player.Knockback(0.02f, 70, player.transform.position));
        }

    }
}
