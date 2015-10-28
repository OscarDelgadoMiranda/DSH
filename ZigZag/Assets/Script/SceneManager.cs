using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {
	
	public static double tiempo;
	public static int score;

	static SceneManager Instance;
	// Use this for initialization
	void Start () 
	{
		if (Instance != null) {
			GameObject.Destroy (gameObject);
		} 
		else 
		{
			GameObject.DontDestroyOnLoad(gameObject);
			Instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		tiempo = pelota.temporizadorDouble;
		score = DestruirCubo.Destruidos;
		Debug.Log(tiempo);
	}
}
