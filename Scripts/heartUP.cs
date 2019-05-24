using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartUP : MonoBehaviour
{
    public static heartUP instance;
    private PlayerManager player;
    //Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        if (instance == null)
        {
            instance = this;
        }
    }

    public void heartOneUP()
    {
        if(player.playerHealth < 5)
        {
            player.playerHealth += 1;
        } 
    }

}
