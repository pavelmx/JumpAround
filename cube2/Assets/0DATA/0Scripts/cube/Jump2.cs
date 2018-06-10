using System.Collections;
using UnityEngine;

public class Jump2 : MonoBehaviour {

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

	void Start(){
		rb2d = this.gameObject.GetComponent<Rigidbody2D>();
	}
	void Update() {
		
		if (Input.GetMouseButtonDown(0)) {
			switch(ground){
			case 0:
				distance_x = distance+1f;
				distance_y = 0;
				side = Vector3.up;
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
			Vector2 pos = new Vector2(this.gameObject.GetComponent<Transform>().position.x + distance_x, this.gameObject.GetComponent<Transform>().position.y + distance_y);
			StartCoroutine(Hop(pos, time));
			rb2d.WakeUp();
		}

		switch(ground)
		{
			case 0:
				rb2d.gravityScale = 1f;
				rb2d.velocity = new Vector2(1f* speed,0f);
		 
				break;
			case 1:
				rb2d.velocity = new Vector2(0f,1f* speed);
				break;
			case 2:
				rb2d.gravityScale = -1f;
				rb2d.velocity = new Vector2(-1f* speed,0f);
				break;
			case 3:
				rb2d.velocity = new Vector2(0f,-1f* speed);
				break;
		}
	}

	IEnumerator Hop(Vector2 dest, float time) {
		rb2d.Sleep();
		if (hopping) yield break;
		hopping = true;
		var startPos = transform.position;
		var timer = 0.0f;

		while (timer <= 1.0f) {
			var height = Mathf.Sin(Mathf.PI * timer) * hopHeight;  
			transform.position = Vector3.Lerp(startPos, dest, timer) + side * height;   
			timer += Time.deltaTime / time;
			yield return null;
		}
		hopping = false;
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "GroundUp"){
			ground = 0;
			StopAllCoroutines();
			hopping = false;
		}
		if(other.gameObject.tag == "GroundDown"){
			ground = 2;
			StopAllCoroutines();
			hopping = false;
		}
		if(other.gameObject.tag == "GroundLeft"){
			ground = 1;
			StopAllCoroutines();
			hopping = false;
		}
		if(other.gameObject.tag == "GroundRight"){
			ground = 3;
			StopAllCoroutines();
			hopping = false;
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
