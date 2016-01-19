using UnityEngine;
using System.Collections;

public class Cargar_Partida : MonoBehaviour {

	public void Cargar()
	{
		Cargar_Barras.CargarBool = true;
		Application.LoadLevel("Proyecto");
	}
}
