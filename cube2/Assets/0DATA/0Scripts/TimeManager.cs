using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour
{

    static private bool rew;
    public KeyCode key = KeyCode.Space;

    public static bool Rewind
    {
        get { return rew; }
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            rew = true;
        }
        else
        {
            rew = false;
            Time.timeScale = 1;
        }
    }
}
