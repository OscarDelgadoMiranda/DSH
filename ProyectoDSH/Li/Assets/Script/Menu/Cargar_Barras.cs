using UnityEngine;
using System.Collections;

public class Cargar_Barras : MonoBehaviour {

		public static bool CargarBool = false;

		void Update()
		{
			if(CargarBool == true)
			{
				Guardado.Cargar();
				CargarBool = false;
			}
		}
}
