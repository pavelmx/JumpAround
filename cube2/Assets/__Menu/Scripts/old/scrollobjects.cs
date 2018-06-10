using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollobjects : MonoBehaviour
{

	public float speed = 3f, checkPos = -1660f;
	private RectTransform rec;
    
   

    void Start()
    {
        rec = GetComponent <RectTransform> ();
    }

    void Update()
    {
        if (rec.offsetMin.x != checkPos)
        {
            rec.offsetMin += new Vector2(speed, rec.offsetMin.y);
            rec.offsetMax += new Vector2(speed, rec.offsetMax.y);
        }
    }
}
