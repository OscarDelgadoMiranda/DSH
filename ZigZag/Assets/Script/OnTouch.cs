using UnityEngine;
using System.Collections;

public class OnTouch : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*var touch = Input.GetTouch (0).phase;
		if (touch == TouchPhase.Began)
			Application.LoadLevel (0);
		*/if (Input.touchCount >= 1)
			Application.LoadLevel (0);
	}
}
