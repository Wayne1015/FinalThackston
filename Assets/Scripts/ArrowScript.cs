using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowScript : MonoBehaviour {
   
    Rigidbody2D rb;
    public Vector2 dir = new Vector2(0, 0);

    private AudioSource audioSource;

    private NinjaControllerScript player;
    private BoxCollider2D box;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindObjectOfType<NinjaControllerScript>();
        box = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = dir;
  
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            player.myRigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;

            player.anim.SetBool("Dead", true);

            player.dead = true;
            box.enabled = false;
            spriteRenderer.enabled = false;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

     
   
   
    
}
