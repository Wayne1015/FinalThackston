using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpaw : MonoBehaviour {

    public ArrowScript arrowPrefab;
    
    public float arrowSpeed;
    public float upOrDownSpeed;
    private float time = 0;
    
    public float arrowDelay;

    
    public bool fromLeft = false;
    
    
    public bool shoot;

    private Vector2 dir;
    

	// Use this for initialization
	void Start () {
        dir = new Vector2(arrowSpeed, upOrDownSpeed);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(shoot == true)
        {
            if (time < Time.time)
            {
                ArrowScript arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as ArrowScript;
                
                
                if(fromLeft == true)
                {
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
              
                else
                {
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                time = Time.time + arrowDelay;
                arrow.dir = dir;
            }
                
               
            
        }



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoot = true;
        }
    }

    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shoot = false;
        }
    }
}
