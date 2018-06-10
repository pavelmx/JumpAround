using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StarAnimation : MonoBehaviour
{
    private SpriteRenderer star;
    //public float movespeed = Random.Range(0f, 3f);

    void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time/2.5f, 1f));
        transform.position += transform.up* Time.deltaTime * Random.Range(0f, 0.7f);   
    }
}
