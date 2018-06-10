using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLevel1 : MonoBehaviour {

    public GameObject Cube;
    public Text ScoreText;
    private int score ;
    public static int scorenumber;
    float oldX;


    

    int ScoreNumber()
    {
        if (Cube != null)
        {
            float x = Cube.transform.position.x;
            if (oldX <= -12.5f && x >= -12.5f)
            {
                score++;
            }
            oldX = x;
        }
            return score;
    }

    void Update () {

        ScoreText.text = ScoreNumber().ToString();
        scorenumber = ScoreNumber() ;
      
    }
}
