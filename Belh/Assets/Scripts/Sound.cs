using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour 
{
	//audio clips
	public AudioClip shootSound;
	public AudioClip reloadSound;
	public AudioClip blinkSound;
	public AudioClip backSound;
	public AudioClip breakingSound;

	public float volume;
	public float backvolume = .5f;

	//array and audio source
	private AudioSource[] audSources;
	public GameObject audSource;


	void Start() //Creates an array of game objects and assigns aduio sources to the game objects
	{
		audSources = new AudioSource[32]; //32, why? Fuck you that's why
		for (int i = 0; i < audSources.Length; i++)
		{
			audSources[i] = (Instantiate(audSource, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<AudioSource>();
		}
		audSources[0].PlayOneShot(backSound, backvolume); //background music
	}

	//plays sound on the assigned game object
	public void Shot()
	{
		audSources[1].PlayOneShot(shootSound, volume);
	}

	public void Reload()
	{
		audSources[2].PlayOneShot(reloadSound, volume);
	}
	public void Blink()
	{
		audSources[3].PlayOneShot(blinkSound, volume);
	}
	public void Breaking()
	{
		audSources[4].PlayOneShot(breakingSound, volume);
	}
}
