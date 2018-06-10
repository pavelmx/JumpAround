using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeTest : MonoBehaviour {

    public swipe swipeControls;
    public Transform player;
    private Vector3 diseredposition;
	

	void Update () {

        if (swipeControls.SwipeLeft) { diseredposition += Vector3.left; }
        if (swipeControls.SwipeRight) { diseredposition += Vector3.right; }
        if (swipeControls.SwipeUp) { diseredposition += Vector3.forward; }
        if (swipeControls.SwipeDown) { diseredposition += Vector3.down; }

        player.transform.position = Vector3.MoveTowards(player.transform.position,diseredposition*17.78f,40f*Time.deltaTime);

        if (swipeControls.Tap)
            Debug.Log("tap!");
        
    }
}
