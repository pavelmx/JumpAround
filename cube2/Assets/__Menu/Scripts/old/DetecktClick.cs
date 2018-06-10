using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecktClick : MonoBehaviour
{

    private void OnMouseDown()
    {
        print("click");
    }

    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "detectclicks":
                Application.LoadLevel("level1");
                break;
        }
    }
}
