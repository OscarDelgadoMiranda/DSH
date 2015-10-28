using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MostrarPuntuacion : MonoBehaviour {


	public Text score;
	public Text tiempo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		tiempo.text = SceneManager.tiempo.ToString ();
		score.text = SceneManager.score.ToString ();
		Debug.Log (tiempo);
	}
}
