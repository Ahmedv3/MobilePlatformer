using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCtrl : MonoBehaviour
{

    public Transform player;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal
       // transform.position = new Vector3(player.position.x, player.position.y,transform.position.z);

        // horizontal / vertical
        transform.position = new Vector3(player.position.x,player.transform.position.y+yOffset,transform.position.z);

    }
}
