using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonsscroll : MonoBehaviour {

     void OnMouseDown()
    {
        transform.localScale = new Vector3(0.8f,0.8f,0.8f);
    }
     void OnMouseUp()
    {
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        
    }
}
