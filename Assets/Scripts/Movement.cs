using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{

	public float blinkSpeed = 30f;
	public float coolDown = 2.0f;
	float nextBlink;
	int number;
	bool cooled = true;

	public float movementSpeed = 15f;

	public float reloadingMoveSpeed = 8f;

	float defaultMoveSpeed;

	Sound sound;

	TrailRenderer blinkLine;

	/*
	public float Leftbound = -25;
	public float Rightbound = 25;
	public float Topbound = 15;
	public float Bottombound = -15;
	*/

	Rigidbody2D rb;

	Vector2 moveVect;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		blinkLine = GetComponent<TrailRenderer>();
		sound = GetComponent<Sound>();
		moveVect = Vector2.zero;
		defaultMoveSpeed = movementSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetInput();
	}
	
	void FixedUpdate ()
	{
		Movementinput();

		if (Global.me.reloading == true)
		{
			movementSpeed = reloadingMoveSpeed;
		}
		if (Global.me.reloading == false)
		{
			movementSpeed = defaultMoveSpeed;
		}

		//Boundries();
	}
	
	void SetInput ()
	{
		moveVect = Vector2.zero;
		if (Input.GetKey(KeyCode.W))
		{
			moveVect.y += 1;
		}

		if (Input.GetKey(KeyCode.S))
		{
			moveVect.y -= 1;
		}

		if (Input.GetKey(KeyCode.D))
		{
			moveVect.x += 1;
		}

		if (Input.GetKey(KeyCode.A))
		{
			moveVect.x -= 1;
		}

		if ((Input.GetKeyDown(KeyCode.Space) && cooled == true)) //Blink 
		{
			movementSpeed *= blinkSpeed;
			number += 1;
			sound.Blink();
			if (number == 2)
			{
				cooled = false;
			}
		}
		if (cooled == false && Time.time > nextBlink)
		{
			nextBlink = Time.time + coolDown;
			number = 0;
			cooled = true;
		}

		moveVect = moveVect.normalized;

	}
	
	public void Movementinput() //bases movement on ridgidbody 
	{    
		rb.MovePosition(transform.position + (Vector3)moveVect * movementSpeed * Time.fixedDeltaTime);
		if (movementSpeed != defaultMoveSpeed)
		{
			movementSpeed = defaultMoveSpeed;
		}
	}
}
