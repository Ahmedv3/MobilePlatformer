using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour
{

    public turretAI turretAI;
    public bool isLeft = false;


    void Awake()
    {
        turretAI = gameObject.GetComponentInParent<turretAI>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                
                turretAI.attack(false);
            }
            else
            {
                
                turretAI.attack(true);
            }
        }
    }

    

}


