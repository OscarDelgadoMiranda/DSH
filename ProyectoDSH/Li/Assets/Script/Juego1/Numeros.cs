using UnityEngine;
using System.Collections;

public class Numeros : MonoBehaviour {

	public GameObject canvas;
	private GameObject carpeta;
	private GameObject boton_leon;
	private GameObject opcion_1, opcion_2,opcion_3;
	private GameObject pregunta;
	private GameObject animos_;
	// Use this for initialization
	void Start () 
	{
		carpeta = canvas.transform.FindChild ("ButtonLion").gameObject;
		opcion_1 = canvas.transform.FindChild ("opcion1").gameObject;
		opcion_2 = canvas.transform.FindChild ("opcion2").gameObject;
		opcion_3 = canvas.transform.FindChild ("opcion3").gameObject;
		pregunta = canvas.transform.FindChild ("Suma").gameObject;
		animos_ = canvas.transform.FindChild ("Texto_respuesta").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ControlTarget.presencia_numeros == true) {
			carpeta.SetActive (false);
			opcion_1.SetActive (true);
			opcion_2.SetActive (true);
			opcion_3.SetActive (true);
			pregunta.SetActive (true);
			animos_.SetActive (true);
		} else {
			carpeta.SetActive (true);
			opcion_1.SetActive (false);
			opcion_2.SetActive (false);
			opcion_3.SetActive (false);
			pregunta.SetActive (false);
			animos_.SetActive(false);
		}
			
	}
}
