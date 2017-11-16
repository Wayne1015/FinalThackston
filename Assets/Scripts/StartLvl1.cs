using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLvl1 : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Action"))
        {
            SceneManager.LoadScene("Lvl1");
        }
	}
}
