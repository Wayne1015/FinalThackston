using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayeronLeaving : MonoBehaviour {

    Coins coin;
    // Use this for initialization
    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (CheckPoint.currentActiveCheckPoint == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Coins.coinCount = 0;
            }
            else
            {
                other.gameObject.transform.position =
                    CheckPoint.currentActiveCheckPoint.transform.position;
            }
        }
    }
   
}
