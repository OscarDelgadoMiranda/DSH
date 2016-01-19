using UnityEngine;
using System.Collections;

public class Guardado : MonoBehaviour 
{

	public static void Grabar()
	{
		PlayerPrefs.SetInt("Sed",ControlTarget.currentSed);
		PlayerPrefs.Save();
		PlayerPrefs.SetInt("Hambre",ControlTarget.currentHambre);
		PlayerPrefs.Save();
		PlayerPrefs.SetInt("Felicidad",ControlTarget.currentFelicidad);
		PlayerPrefs.Save();
		PlayerPrefs.SetInt("Chuletas",ControlTarget.nChuletas);
		PlayerPrefs.Save();
	}

	public static void Cargar()
	{
		ControlTarget.currentSed = PlayerPrefs.GetInt("Sed",100);
		ControlTarget.currentHambre = PlayerPrefs.GetInt("Hambre",100);
		ControlTarget.currentFelicidad = PlayerPrefs.GetInt("Felicidad",100);
		ControlTarget.nChuletas = PlayerPrefs.GetInt("Chuletas",1);
	}
}
