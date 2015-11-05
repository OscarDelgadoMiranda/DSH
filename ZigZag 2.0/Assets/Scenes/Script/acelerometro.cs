﻿using UnityEngine;
using System.Collections;

public class acelerometro : MonoBehaviour 
{
	//private Rigidbody rigidbody;
	// Update is called once per frame
	void Update () 
	{
		if (this.transform.position.y < 0) 
		{
			Vector3 pos = transform.position;
			pos.x = 1f;
			pos.y = 0.75f;
			pos.z = 2f;
			PlayerPrefs.SetInt("puntosactuales", 0);
			PlayerPrefs.Save();
			Application.LoadLevel ("Final");
		}
		var speed = 3f;

	 	Vector3 dir = Vector3.zero;
		
		// we assume that the device is held parallel to the ground
		// and the Home button is in the right hand
		
		// remap the device acceleration axis to game coordinates:
		// 1) XY plane of the device is mapped onto XZ plane
		// 2) rotated 90 degrees around Y axis
		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;
		
		// clamp acceleration vector to the unit sphere
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		// Make it move 10 meters per second instead of 10 meters per frame...
		dir *= Time.deltaTime;
		
		// Move object
		transform.Translate (dir * speed);
	}
}
