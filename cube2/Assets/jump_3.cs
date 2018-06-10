using System.Collections;
using UnityEngine;

public class jump_3 : MonoBehaviour {

	public float hopHeight = 1.25f;
	private bool hopping = false;

	Rigidbody2D rb2d;

	public float time;
	public float speed = 10f;
	private float distance_x, distance_y;
	public float distance = 5;
	public int ground;
	private Animation anim;
	Vector3 side;

	void Start()
	{
		rb2d = this.gameObject.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			switch(ground){
			case 0:
				
				//rb2d.AddForce (new Vector2 (0f, 1000f));
				Vector3 move = new Vector3 (0f, hopHeight, 0f);
				rb2d.velocity = move;
				Debug.Log ("jump!!!!");
				break;
			case 1:
				distance_x = 0;
				distance_y = distance;
				side = Vector3.left;
				break;
			case 2:
				distance_x = -distance;
				distance_y = 0;
				side = Vector3.down;
				break;
			case 3:
				distance_x = 0;
				distance_y = -distance;
				side = Vector3.right;
				break;
			}
		}


		switch(ground)
		{
		case 0:
			
			Vector3 move2 = new Vector3 (speed, transform.position.y, 0f);
			rb2d.velocity = move2;

			break;
		case 1:
			rb2d.velocity = new Vector2(0f,1f* speed);
			break;
		case 2:
			rb2d.velocity = new Vector2(-1f* speed,0f);
			break;
		case 3:
			rb2d.velocity = new Vector2(0f,-1f* speed);
			break;
		}
	}



	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "GroundUp"){
			ground = 0;
		

		}
		if(other.gameObject.tag == "GroundDown"){
			ground = 2;


		}
		if(other.gameObject.tag == "GroundLeft"){
			ground = 1;


		}
		if(other.gameObject.tag == "GroundRight"){
			ground = 3;
		
		}
		if (other.gameObject.tag == "TriangleEnemy")
		{
			anim = GetComponent<Animation>();
			anim.Play("lose");
			print("LOSE");

			Destroy(gameObject, 1f);
		}

	}
}
