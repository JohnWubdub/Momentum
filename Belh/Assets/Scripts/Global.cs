using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour 
{

	public static Global me;
	public bool reloading = false;
	public Screenshake screenshake; 


	private void Awake()
	{
		me = this; //awakens the script
	}
}
