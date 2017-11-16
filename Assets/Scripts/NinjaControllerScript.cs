using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NinjaControllerScript : MonoBehaviour {

    [SerializeField]
    Transform WallDetectPointFacingRight;

    [SerializeField]
    Transform WallDetectPointFacingLeft;

    [SerializeField]
    float WallDetectRadius = 0.2f;

    
      float WallDetectBackRadius = 0.3f;

    [SerializeField]
    LayerMask whatCountsAsWalls;


    public float maxSpeed = 10;

    bool facingRight = true;

    public Animator anim;

    [SerializeField]
    bool alreadyJumpedOnce = false;
    

    private bool grounded = false;

    public Transform groundCheck;

    private float groundRadius = 0.2f;

    public LayerMask whatIsGround;

    public float jumpForce = 700f;

    public Rigidbody2D myRigidBody2D;

    [SerializeField]
    bool isOnWall;

    [SerializeField]
    bool isBackOnWall;

    private AudioSource audioSource;

    public bool dead;
    private Coins coins;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Move();
    }

    private void CheckforGround()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", myRigidBody2D.velocity.y);
    }

    public void Move()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        myRigidBody2D.velocity = new Vector2(move * maxSpeed, myRigidBody2D.velocity.y);

 

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Update()
    {
        Jump();

        UpdateIsOnWallRight();
        UpdateIsOnWallLeft();
        CheckforGround();

        if(dead == true)
        {
            if(Input.GetButton("Action"))
            {
                anim.SetBool("Dead", false);
                dead = false;
                

                Coins.coinCount = 0;
                if (CheckPoint.currentActiveCheckPoint != null)
                {
                    this.transform.position = CheckPoint.currentActiveCheckPoint.transform.position;
                    

                    myRigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    
                }
            }
        }

        

    }


    private void UpdateIsOnWallRight()
    {
        Collider2D[] wallObjects = Physics2D.OverlapCircleAll(WallDetectPointFacingRight.position, WallDetectRadius, whatCountsAsWalls);
        isOnWall = wallObjects.Length > 0;
    }

    private void UpdateIsOnWallLeft()
    {
        Collider2D[] wallObjects2 = Physics2D.OverlapCircleAll(WallDetectPointFacingLeft.position, WallDetectBackRadius, whatCountsAsWalls);

        isBackOnWall = wallObjects2.Length > 0;
    }

   public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = myRigidBody2D.transform.localScale;
        theScale.x *= -1;
        myRigidBody2D.transform.localScale = theScale;
        
    }

   public void Jump()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded && !isOnWall)
            {
                DoJump();
                alreadyJumpedOnce = true;
            }

            else if (alreadyJumpedOnce)
            {
                DoJump();
                alreadyJumpedOnce = false;
            }

            else if (isOnWall || isBackOnWall)
            {
                DoJump();
                audioSource.Play();
            }
        }

    }

    private void DoJump()
    {
        myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, y: jumpForce);
        audioSource.Play();
    }
}
