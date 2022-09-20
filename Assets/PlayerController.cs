using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround; 
    public float dashMultiplier = 3.0f;
    public float maxSpeed = 5.0f;
    public float jumpForce = 100.0f;
    public bool isOnGround= false;  
    //reference to Rigid body to allow it to be maipulated
    Rigidbody2D playerObject;
    float movementValueX = 0.0f;

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
        movementValueX = Input.GetAxis("Horizontal");

        //Change the X velocity of the Rigidbody2D to be equal tothe movement value
        playerObject.velocity = new Vector2(movementValueX * maxSpeed,playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);
        
        //Sprint or Dash
       
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, 2.5f) * jumpForce);
        }
        //Double Jump
        if (Input.GetKeyDown(KeyCode.Space) &&  isOnGround == false)
        {
            playerObject.AddForce(new Vector2(0.0f, 2.0f) * jumpForce);
        }
    }
}
