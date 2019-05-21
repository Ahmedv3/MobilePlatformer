using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private bool damage;
    private float damageTimer = 0;
    private float damageCd = 10.0f;

    public Collider2D damageTrigger;
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        damageTrigger.enabled = false;
    }

    void Update()
    {
        damage = false;
        damageTimer = damageCd;
        damageTrigger.enabled = true;

        if (!damage)
        {
            if (damageTimer > 0)
            {
                damageTimer -= Time.deltaTime;
                
            }
            else
            {
                damage = true;
                damageTrigger.enabled = false;
            }
        }
        //anim.SetBool("damage", damage);

    }
}
