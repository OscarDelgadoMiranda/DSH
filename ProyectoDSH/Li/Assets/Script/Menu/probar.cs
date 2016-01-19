using UnityEngine;
using System.Collections;

public class probar : MonoBehaviour {

public void Probar_boton()
	{
		Guardado.Grabar ();
		Application.LoadLevel("Menu");
	}
}
