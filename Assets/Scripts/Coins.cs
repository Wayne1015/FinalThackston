using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{

    private Text coinCountText;

    

  

    public static int coinCount = 0;



    private BoxCollider2D BoxCollider2d;

    
    private AudioSource audioSource;
    




    // Use this for initialization
    void Start()
    {
        coinCountText = GameObject.Find("CoinCount").GetComponent<Text>();
        BoxCollider2d = GetComponent<BoxCollider2D>();

       
     
        audioSource = GetComponent<AudioSource>();

        

        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();

            coinCount++;

            coinCountText.text = "Coin Count: " + coinCount;

            BoxCollider2d.enabled = false;

            



        }
    }
}
