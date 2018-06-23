using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	//Movement
	public float speed;
	public float jump;
	float moveVelocity;

	//Grounded Vars
	bool grounded = true;

	void FixedUpdate () 
	{
		//Jumping
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) 
		{
			if(grounded)
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
			}
		}

		moveVelocity = 0;

		//Left Right Movement
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
		{
			moveVelocity = -speed;
		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
		{
			moveVelocity = speed;
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
	}
	//Check if Grounded
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag=="Floor")
			grounded = true;
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag=="Floor")
			grounded = false;
	}
}