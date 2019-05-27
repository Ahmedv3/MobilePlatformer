using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevelScreen : MonoBehaviour
{
    public PlayerManager player;
    public GameObject nextLevel;
    private bool paused = false;

    void Awake()
    {
        nextLevel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            paused = true;
            if (paused)
            {
                nextLevel.SetActive(true);
                Time.timeScale = 0;
            }

            if (!paused)
            {
                nextLevel.SetActive(false);
                Time.timeScale = 1;

            }
        }
    }
}
