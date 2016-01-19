using UnityEngine;
using System.Collections;

public class Figuras : MonoBehaviour {
	public GameObject canvas;
	private GameObject figura_1;
	private GameObject figura_2;
	private GameObject figura_3;
	private GameObject animos_;

	void Start () 
	{
		figura_1 = canvas.transform.FindChild ("Circulo").gameObject;
		figura_2 = canvas.transform.FindChild ("Cuadrado").gameObject;
		figura_3 = canvas.transform.FindChild ("Triangulo").gameObject;
		animos_ = canvas.transform.FindChild ("Respuesta_Figuras").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ControlTarget.presencia_figuras == true) {
			figura_1.SetActive (true);
			figura_2.SetActive (true);
			figura_3.SetActive (true);

			animos_.SetActive (true);
		} else {
			figura_1.SetActive (false);
			figura_2.SetActive (false);
			figura_3.SetActive (false);
			animos_.SetActive(false);
		}
		
	}
}
