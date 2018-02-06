using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{

	Rigidbody2D rb;
	public float force = 25;
	float strayFactor = 3f;
	bool shootOnStart = true;

	public int bulletsLeft;
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		
	}

	void FixedUpdate ()
	{
		if (shootOnStart == true)
		{
			float X = Random.Range(-strayFactor, strayFactor);
			float Y = Random.Range(-strayFactor, strayFactor);
			float Z = Random.Range(-strayFactor, strayFactor);
			rb.transform.Rotate(X, Y, Z);
			rb.AddForce(transform.up * force, ForceMode2D.Impulse);
			shootOnStart = false;
			Destroy(gameObject, 3f);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Barrel")
		{
			Destroy(gameObject);
			Debug.Log("whYYYy");
		}
	}
}
