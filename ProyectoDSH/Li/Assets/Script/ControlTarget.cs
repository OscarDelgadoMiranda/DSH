using UnityEngine;
using System.Collections;

public class ControlTarget : MonoBehaviour {

	public static bool tocar;
	public static bool llamar_leon;
	public static int currentFelicidad;
	public static int currentHambre;
	public static int currentSed;
	public static bool salirUpdate;

	public static bool fuegos;
	public static bool fuegos2;
	//Control de juegos
	public static bool tocarboton = false;
	public static int boton_elegido;
	public static bool presencia_figuras;
	public static bool presencia_numeros;
	public static int nChuletas = 1;
	public static int score =0;
	// Use this for initialization

	void Start () 
	{
		fuegos = false;
		fuegos2 = false;
		tocar = false;
		llamar_leon = false;
		presencia_numeros = false;
		presencia_figuras = false;
	}
	

}
