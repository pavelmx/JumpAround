using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollEnemy : MonoBehaviour {

    private GameObject tr10;
    private GameObject tr12;
    private GameObject tr3;
    private GameObject tr4;
    private GameObject tr5;
    private GameObject tr6;
    private GameObject tr15;
    private GameObject tr16;
    private GameObject win;
    public GameObject Cube;
    public float speed = 1f;
    private int score;
    public Text WinText;


    void Start()
    {
        tr10 = GameObject.Find("10");
        tr12 = GameObject.Find("12");
        tr15 = GameObject.Find("15");
        tr16 = GameObject.Find("16");
        tr3 = GameObject.Find("3");
        tr4 = GameObject.Find("4");
        tr5 = GameObject.Find("5");
        tr6 = GameObject.Find("6");
        win = GameObject.Find("WIN");
    }

    void Update()
    {
        score = ScoreLevel1.scorenumber;

        if (score == 1)
        {
            if (tr4.transform.localPosition.y < 0.6)
            {
                tr4.transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
                
            }
            if (tr5.transform.localPosition.x > 7.6)
            {
                tr5.transform.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
        if (score == 2)
        {
            if (tr6.transform.localPosition.x > 7.6)
            {
                tr6.transform.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
        if (score == 3)
        {
            if (tr10.transform.localPosition.y > 8.9)
            {
                tr10.transform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
        if (score == 4)
        {
            if (tr12.transform.localPosition.y > 8.9)
            {
                tr12.transform.localPosition -= new Vector3(0, speed * Time.deltaTime, 0);
            }
        }
        if (score == 5)
        {
            if (tr3.transform.localPosition.y < 0.6)
            {
                tr3.transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            }
            if (tr16.transform.localPosition.x < -8.5)
            {
                tr16.transform.localPosition += new Vector3( speed * Time.deltaTime, 0, 0);
            }
        }

        if(score == 6)
        {
            WinText.text = "!!!YOU WIN!!!";
            if (win.transform.position.y > 0)
            {
                win.transform.position -= new Vector3(0, 20f * Time.deltaTime,  0);
            }
            Destroy(Cube, 1f);
        }


        if (Cube == null)
        {
            if (win.transform.position.y > 0)
            {
                win.transform.position -= new Vector3(0, 40f * Time.deltaTime, 0);
            }

        }
        }
}
