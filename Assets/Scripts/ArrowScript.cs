using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowScript : MonoBehaviour {
   
    Rigidbody2D rb;
    public Vector2 dir = new Vector2(0, 0);
    
    private NinjaControllerScript player;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindObjectOfType<NinjaControllerScript>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = dir;
  
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {

            player.myRigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;

            player.anim.SetBool("Dead", true);

            player.dead = true;

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

     
   
   
    
}
