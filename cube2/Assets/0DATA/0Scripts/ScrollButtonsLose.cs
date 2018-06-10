using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollButtonsLose : MonoBehaviour
{
    public float speed = 10f;
    public GameObject Cube;
    // Use this for initialization

    void Update()
    {
        if (Cube == null) {
            if (gameObject.transform.position.y < 0f)
            {
                gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);

            }
        }
    }

}
