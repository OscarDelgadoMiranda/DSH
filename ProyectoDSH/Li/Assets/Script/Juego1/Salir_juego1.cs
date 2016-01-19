using UnityEngine;
using System.Collections;

public class Salir_juego1 : MonoBehaviour {

	public GameObject Li;
	public GameObject[] HitosPatronMovimiento;
	public static bool  salir_update_juego = true;
	void Start()
	{
		salir_update_juego = true;
	}
	
	void Update()
	{
		//Debug.Log ("Estoy en salir");
		if (salir_update_juego == false) {
			Debug.Log ("Estoy en salir");
			ActivarPatrones ();
			Li.GetComponent<ComportamientoPatron> ().enabled = true;
			salir_update_juego = true;
		}
	}
	
	public void ActivarPatrones()
	{
		for (int HitoSiguiente = 0; HitoSiguiente <HitosPatronMovimiento.Length; HitoSiguiente++)
		{
			HitosPatronMovimiento[HitoSiguiente].SetActive(true);
		}
	}
}
