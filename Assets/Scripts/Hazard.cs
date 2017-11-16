using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            if (CheckPoint.currentActiveCheckPoint == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                other.gameObject.transform.position = 
                    CheckPoint.currentActiveCheckPoint.transform.position;
            }
        }
    }


 
}
