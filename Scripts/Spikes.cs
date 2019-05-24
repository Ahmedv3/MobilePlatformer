using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour  
{

    public int dmg;
    private PlayerManager player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessageUpwards("Damage", dmg);
        player.knockup();
    }


}
