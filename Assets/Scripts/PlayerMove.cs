using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField]
    float jumpStrength = 10;

    [SerializeField]
    float movementspeed = 6.6f;

    [SerializeField]
    Transform GroundDetectPoint;

    [SerializeField]
    Transform WallDetectPointLeft;

   

    [SerializeField]
    float GroundDetectRadius = 0.2f;

    [SerializeField]
    float WallDetectRadius = 0.2f;

    [SerializeField]
    LayerMask whatCountsAsGrounds;

    [SerializeField]
    LayerMask whatCountsAsWalls;

    [SerializeField]
    bool firstJump = false;


    [SerializeField]
    bool isOnGround;

    [SerializeField]
    bool isOnWall;

    //[SerializeField]
    Rigidbody2D myRigidBody;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("Called From Start.");
        //this code puts the player in the center
        //transform.position = new Vector3(0,0,0);
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateIsOnGround();
        UpdateIsOnWallLeft();
        
        Move();
        Jump();
    }

    private void UpdateIsOnGround()
    {
       Collider2D[] groundObjects = Physics2D.OverlapCircleAll(
            GroundDetectPoint.position, GroundDetectRadius, whatCountsAsGrounds);

        isOnGround = groundObjects.Length > 0;
    }

    private void UpdateIsOnWallLeft()
    {
        Collider2D[] wallObjects = Physics2D.OverlapCircleAll(WallDetectPointLeft.position, WallDetectRadius, whatCountsAsWalls);

        isOnWall = wallObjects.Length > 0;
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        firstJump = false;
        
    }

    private void Jump()
    {
        
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, y: jumpStrength);
            
            firstJump = true;

        }
        else if(firstJump == true && Input.GetButtonDown("Jump"))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, y: jumpStrength);
            firstJump = false;
        }

        else if(Input.GetButton("Jump") && isOnWall)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, y: jumpStrength);
            isOnWall = false;

            firstJump = true;
        }

    }

    private void Move()
    {
        //programming for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //Changes the velocity of the gameobject 

        //code for jumping
        myRigidBody.velocity = new Vector2(horizontalInput * movementspeed, myRigidBody.velocity.y);
    }


}
