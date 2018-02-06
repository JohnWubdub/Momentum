using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour {

	Vector3 defaultCameraPos;
	Vector3 weightedDirection;
	float screenshakeTimer = 0;
	float thisMagnitude = 0;

	void Start()
	{
		defaultCameraPos = new Vector3(0, 0, -10);
	}


	void Update()
	{
		if (screenshakeTimer > 0)
		{
			Vector3 shakeDirection = ((Vector3)Random.insideUnitCircle + weightedDirection).normalized * thisMagnitude * Mathf.Clamp01(screenshakeTimer); //stops it at one so it won't 

			Vector3 result = defaultCameraPos + shakeDirection;
			result.z = -10f;
			transform.localPosition = result;

			screenshakeTimer -= Time.deltaTime;
		}

	}

	public void SetScreenShake(float magnitude, float duration, Vector3 direction)
	{
		thisMagnitude = magnitude;
		screenshakeTimer = duration;
		weightedDirection = direction;
	}

	public void SetScreenShake(float magnitude, float duration)
	{
		SetScreenShake(magnitude, duration, Vector3.zero);
	}
}
