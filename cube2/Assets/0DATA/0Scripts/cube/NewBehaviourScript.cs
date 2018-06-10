using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float jump = 1.25f;  // высота прыжка
    
    public float speed = 100f;  //скорость
    private bool hopping = false;
    private Animation anim;
    private bool coll;

    Rigidbody2D rb2d;


   

    private float distance_x, distance_y;
   // public float distance = 3; //дальность прыжка

    public int ground; //поверхность

    //Vector3 side;

    void Start()
    {
        if (gameObject != null)
        {
            rb2d = this.gameObject.GetComponent<Rigidbody2D>();

        }
    }
    void Update()
    {

        if (gameObject != null)
        {


            //this.gameObject.GetComponent<Transform>().InverseTransformPoint((this.gameObject.GetComponent<Transform>()).position);
            if (Input.GetMouseButtonDown(0))
            {
                switch (ground)
                {
                    case 0:
                      //  distance_x = distance;
                      //  distance_y = 0;                     
                        rb2d.AddForce(new Vector2(0f, jump)); 
                        break;
                    case 1:
                        // distance_x = 0;
                        // distance_y = distance;
                        rb2d.AddForce(new Vector2(-jump, 0f));
                        break;
                    case 2:
                       // distance_x = -distance;
                        //distance_y = 0;
                        rb2d.AddForce(new Vector2(0f, -jump));
                        break;
                    case 3:
                        // distance_x = 0;
                        // distance_y = -distance;
                        rb2d.AddForce(new Vector2(jump, 0f));
                        break;
                }

              //  Vector2 pos = new Vector2(this.gameObject.GetComponent<Transform>().position.x + distance_x, this.gameObject.GetComponent<Transform>().position.y + distance_y);

            }
            switch (ground)
            {
                case 0:
                    rb2d.gravityScale = 1f;
                    rb2d.velocity = new Vector2(1f * speed, 0f);
                    break;
                case 1:
                    rb2d.velocity = new Vector2(0f, 1f * speed);
                    break;
                case 2:
                    rb2d.gravityScale = -1f;
                    rb2d.velocity = new Vector2(-1f * speed, 0f);
                    break;
                case 3:
                    rb2d.velocity = new Vector2(0f, -1f * speed);
                    break;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject != null)
        {
            if (other.gameObject.tag == "GroundUp")
            {
                ground = 0;
                hopping = false;
            }
            if (other.gameObject.tag == "GroundDown")
            {
                ground = 2;
                hopping = false;
            }
            if (other.gameObject.tag == "GroundLeft")
            {
                ground = 1;
                hopping = false;
            }
            if (other.gameObject.tag == "GroundRight")
            {
                ground = 3;
                hopping = false;
            }

            if (other.gameObject.tag == "TriangleEnemy")
            {
               // anim = GetComponent<Animation>();
               // anim.Play("lose");
                print("LOSE");

                Destroy(gameObject, 1f);
            }

        }
    }
}