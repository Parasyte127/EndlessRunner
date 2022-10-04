using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Reference to the player
    public GameObject player;
    
    
    void Update()
    {
        //Change position releative to the player's position//
        transform.position = new Vector3(player.transform.position.x + 3.0f, player.transform.position.y / 3, transform.position.z);
    }
}
