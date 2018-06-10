using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackground : MonoBehaviour {

	public float speed = 5f;
	public float checkpos = -1660f;
	public float checkpos2 = -1660f;
	public GameObject back;
	public GameObject back2;

	void Update () {

		if (back.transform.position.x > checkpos) {
			back.transform.position -= new Vector3 (speed / 10, 0f, 0f);
			Debug.Log ("yes");
		} else {
			Debug.Log ("no");
		}



	}
}
