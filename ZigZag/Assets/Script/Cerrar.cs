using UnityEngine;
using System.Collections;

public class Cerrar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*var touch = Input.GetTouch (0).phase;
		if (touch == TouchPhase.Began)
			Application.Quit();*/
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}
}
