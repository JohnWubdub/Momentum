using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    //ParticleSystem ps;
    //public Sound sound;

	void Start ()
    {
        //sound = GetComponent<Sound>();
        //ps = GetComponent<ParticleSystem>();
	}
	
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            //Destroy(gameObject);
            Global.me.screenshake.SetScreenShake(.05f, .5f, Vector3.right);
            //sound.Breaking();
            Debug.Log("whYYYy");
        }
    }


}
