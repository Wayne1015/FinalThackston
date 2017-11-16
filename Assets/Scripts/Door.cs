using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    string SceneToLoad;
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetButtonDown("Action"))
            {
                SceneManager.LoadScene(SceneToLoad);
            }
        }
    }
}
