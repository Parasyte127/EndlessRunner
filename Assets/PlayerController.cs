using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundObject;
    public LayerMask whatIsGround; 

    float maxSpeed = 5.0f;
    bool isOnGround= false;  
    //reference to Rigid body to allow it to be maipulated
    Rigidbody2D playerObject;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component tahtis attached tothe same objectas the script
        playerObject =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //create afloat that will be equal to the player's horizontal input
        float movementValueX = Input.GetAxis("Horizontal");

        //Change the X velocity of the Rigidbody2D to be equal tothe movement value
        playerObject.velocity = new Vector2(movementValueX,playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);
        
    }
}
