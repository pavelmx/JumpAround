using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Buttons : MonoBehaviour {

	void OnMouseUpAsButton () {

        switch (gameObject.name)
        {

            case "home":
                Application.LoadLevel("menu");
                break;
            case "retrylevel1":
                Application.LoadLevel("level1");
                break;
            case "play":
                Application.LoadLevel("levels");
                break;
            case "level1":
                if (gameObject.transform.position.x ==0 )
                {
                    Application.LoadLevel("level1");
                }
                break; 
            case "playmarket":
                Application.LoadLevel("chat");
                break;
        }

	}
	

}
