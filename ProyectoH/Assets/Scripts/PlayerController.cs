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

	int inactiveTime = 0;
	Animator anim;
	GameObject sleep;

	void Start()
	{
		anim = GameObject.FindWithTag ("Player").GetComponent<Animator> ();
		sleep = GameObject.FindWithTag ("Sleep");

		sleep.SetActive (false);
	}

	void FixedUpdate ()
	{
		moveVelocity = 0;

		//Left Movement
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
		{
			moveVelocity = -speed;

			GameObject.FindWithTag ("Player").GetComponent<SpriteRenderer> ().flipX = true;
			sleep.SetActive (false);
			anim.SetBool ("Walking", true);
			anim.SetBool ("Dormida", false);
			inactiveTime = 0;
		}
		//Right Movement
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
		{
			moveVelocity = speed;

			GameObject.FindWithTag ("Player").GetComponent<SpriteRenderer> ().flipX = false;
			sleep.SetActive (false);
			anim.SetBool ("Walking", true);
			anim.SetBool ("Dormida", false);
			inactiveTime = 0;
		}
		//Jumping
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
			if (grounded) 
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
				sleep.SetActive (false);
				inactiveTime = 0;
				anim.SetBool ("Dormida", false);
			}
		} else if (moveVelocity == 0) {
			inactiveTime++;
			anim.SetBool ("Walking", false);

			if (inactiveTime == 500)
				anim.SetTrigger ("Bostezo");
			else if (inactiveTime == 1000) {
				anim.SetBool ("Dormida", true);
				sleep.SetActive (true);
			}
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