using System.Collections;
using UnityEngine;

public class spawnstars : MonoBehaviour {

    public GameObject star;

    void Start() {
        StartCoroutine(spawn());
    }

        IEnumerator spawn()
        {
            while (true)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width),Random.Range(0,Screen.height),Camera.main.farClipPlane/2));
                Instantiate(star, pos, Quaternion.Euler(0 , 0 , Random.Range(0f, 360f)));
                yield return new WaitForSeconds(5f);
            }
        }
	}
	

