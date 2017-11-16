using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    private Text coinCountText;

    [SerializeField]
    Text winner;

    [SerializeField]
    string SceneToLoad;

    [SerializeField]
    public int coinsToWin = 0;


    // Use this for initialization
    void Start()
    {
        coinCountText = GameObject.Find("CoinCount").GetComponent<Text>();

        winner = GameObject.Find("Winner").GetComponent<Text>();
        winner.text = " ";

        coinCountText.text = "Coin Count: " + Coins.coinCount;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            winner.text = ("Press e or up to quit the game.");

            if (Input.GetButtonDown("Action"))
            {
                Application.Quit();
            }
        }
           else
             {
                winner.text = "";
             }
        if (SceneManager.GetActiveScene().name == "Lvl3" && Coins.coinCount == coinsToWin)
        {
            
            winner.text = "Press E or up arrow to go back to level 1 or escape to quit";

                if (Input.GetButtonDown("Cancel"))
                {
                    Application.Quit();
                }
                if(Input.GetButtonDown("Action"))
                {
                    SceneManager.LoadScene(SceneToLoad);
                }
        }
        
        else
        {
                if (Coins.coinCount == coinsToWin)
                {
                winner.text = ("You Win!, " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +
                    "   " +

                    "Press e or up arrow to continue");
      
                     if (Input.GetButtonDown("Action"))
                     {
                        SceneManager.LoadScene(SceneToLoad);
                        Coins.coinCount = 0;
                     }
                }
                            
        }
    }
}

