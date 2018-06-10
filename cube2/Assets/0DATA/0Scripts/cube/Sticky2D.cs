using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Sticky2D : MonoBehaviour {

//	public float speed = 1.5f; // максимальная скорость
	public float acceleration = 100; // ускорение
	public float contactDistance = 1.25f; // дистанция с которой происходит сцепление с поверхностью
	public float gravityForce = 100; // гравитационная сила

	private int layerMask;
	private Rigidbody2D body;
	private float h;
	private Vector3 direction;
	private Vector3 gravity;
    private bool isGrounded ;

    void Awake()
    {
        if (gameObject != null)
        {
            body = GetComponent<Rigidbody2D>();
            //body.gravityScale = 0;

            layerMask = 1 << gameObject.layer | 1 << 2;
            layerMask = ~layerMask;

            // стартовое направление
            direction = Vector3.down;
            gravity = Vector3.down;

            GetDirections(direction, Mathf.Infinity);
        }
    }

	void GetDirections(Vector3 currentDirection, float distance)
	{
        if (gameObject != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDirection, distance, layerMask);
            if (hit.collider)
            {
                SetNormal(hit.normal);
            }


            Scanner();
        }
	}

    void SetNormal(Vector3 normal)
    {
        if (gameObject != null)
        {
            gravity = -normal.normalized; // вектор притяжения к плоскости
            direction = Vector3.Cross(normal, Vector3.forward).normalized; // вектор параллельно плоскости
        }
    }

    void Scanner()
    {
        if (gameObject != null)
        {
            // пускаем лучи от центра во все стороны
            int arr = 6;
            float j = 0;
            float[] distance = new float[arr];
            Vector2[] normal = new Vector2[arr];

            for (int i = 0; i < arr; i++)
            {
                var x = Mathf.Sin(j);
                var y = Mathf.Cos(j);

                j += 360 * Mathf.Deg2Rad / arr;

                Vector3 dir = transform.TransformDirection(new Vector3(x, y, 0));

                RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity, layerMask);
                if (hit.collider)
                {
                    distance[i] = hit.distance;
                    normal[i] = hit.normal;
                    Debug.DrawLine(transform.position, hit.point, Color.cyan);
                }
                else
                {
                    distance[i] = Mathf.Infinity;
                }
            }

            float min = Mathf.Min(distance); // определяем наименьшую дистанцию до нормали

            // перебираем массив, если минимальная дистанция больше
            // чем дистанция прилипания (внешний угол) - меняем плоскость
            for (int i = 0; i < arr; i++)
            {
                if (distance[i] == min && min > contactDistance)
                {
                    SetNormal(normal[i]);

                }
            }
        }
    }

    void LateUpdate()
    {
        if (gameObject != null)
        {
            h = Input.GetAxis("Horizontal");

            GetDirections(direction * h, contactDistance);

            Debug.DrawRay(transform.position, direction * h, Color.red);
        }
    }
    void FixedUpdate()
    {
        if (gameObject != null)
        {

            body.AddForce(gravity * gravityForce * body.mass); // применяем гравитацию

            //body.AddForce(direction * h * speed * acceleration * body.mass); // добавляем вектор движения

            // Ограничение скорости, иначе объект будет постоянно ускоряться
          /*  	if(Mathf.Abs(body.velocity.x) > speed)
                {
                    body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
                }

                if(Mathf.Abs(body.velocity.y) > speed)
                {
                    body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed);
                }*/
        }
    }

}
