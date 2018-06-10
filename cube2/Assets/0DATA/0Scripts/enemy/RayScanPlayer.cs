using UnityEngine;
using System.Collections;

public class RayScanPlayer : MonoBehaviour
{
    
    public float speed = 0.05f;
    public string targetTag = "Player";
    public int rays = 6;
    public int distance = 5;
    public float angle = 20;
    public Vector3 offset;
    private Transform target;
    private GameObject triangle;
    public GameObject Cube;
    private int layerMask;

    void Start()
    {
       
            target = GameObject.FindGameObjectWithTag(targetTag).transform;
        

        layerMask = 1 << gameObject.layer | 1 << 2;
        layerMask = ~layerMask;

    }

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        Vector3 pos = transform.position + offset;
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, distance, layerMask);
        if (hit.collider)
        {
            if (hit.transform == target)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / rays;

            Vector3 dir = transform.TransformDirection(new Vector3(-y, -x, 0));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-y, x, 0));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    void Update()
    {
        if (Cube != null)
        {

            if (Vector2.Distance(transform.position, target.position) < distance)
            {
                if (RayToScan())
                {
                    // Контакт с целью
                 /*   if (gameObject.transform.position.y < 0.6f)
                    {
                        gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                    }*/

                }
                else
                {
                    // Поиск цели...
                   /* if (gameObject.transform.position.y > 0f)
                        gameObject.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                        */
                }
            }
        }
    }
}