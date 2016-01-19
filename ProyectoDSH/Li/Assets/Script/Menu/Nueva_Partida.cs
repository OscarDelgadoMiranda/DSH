using UnityEngine;
using System.Collections;

public class Nueva_Partida : MonoBehaviour 
{
	public void Cargar_Nueva_Partida()
	{
		ControlTarget.currentSed = 100;
		ControlTarget.currentHambre = 100;
		ControlTarget.currentFelicidad = 100;
		ControlTarget.nChuletas = 1;
		Application.LoadLevel("Proyecto");
	}
}
