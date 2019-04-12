using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

	public float carSpeed;
	public float maxPos = 2.2f;
	// public float maxPosY;
	Vector3 position;
	Rigidbody2D rb;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		
	}
	// Use this for initialization
	void Start () {
		position = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
		position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;
		position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
		position.y =  Mathf.Clamp(position.y, -4.4f, 4.46f);
		
		position = transform.position;
		position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
		transform.position = position;
	}
	public void moveLeft(){
		rb.velocity = new Vector2(-carSpeed , 0);
	}
	public void moveRight(){
		rb.velocity = new Vector2(carSpeed , 0);
	}
	public void setVelocityZero(){
		rb.velocity = Vector2.zero;
	}

	void TouchMove(){
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			float middle = Screen.width/2;
			if(touch.position.x < middle && touch.phase == TouchPhase.Began){
				moveLeft();
			}
			else if(touch.position.x > middle && touch.phase == TouchPhase.Began){
				moveRight();
			}
		}
		else{
			setVelocityZero();
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "EnemyCar"){
			Destroy(gameObject);
			Application.LoadLevel("Menu");
		}
	}
}
