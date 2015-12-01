using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class salir : MonoBehaviour {
	public Text textbuttonexit;
	// Use this for initialization
	public void Salir () {
		if(textbuttonexit.text == "Exit")
			Application.Quit ();
	}

}
