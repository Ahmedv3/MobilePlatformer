using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadScreen : MonoBehaviour
{

    public PlayerManager player;
    public GameObject dead;
    private bool paused = false;


    void Start()
    {
        dead.SetActive(false);
    }


    void Update()
    {
        if (player.playerHealth <= 0)
        {
            paused = true;
        }

        if (paused)
        {
            dead.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            dead.SetActive(false);
            Time.timeScale = 1;

        }


    }


}
