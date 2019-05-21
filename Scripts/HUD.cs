using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartsSprites;

    public Image HeartUI;

    private PlayerManager player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
       
    }

    void Update()
    {
        HeartUI.sprite = HeartsSprites[player.playerHealth];
    }
}
