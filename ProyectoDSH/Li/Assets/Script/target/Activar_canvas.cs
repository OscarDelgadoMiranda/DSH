using UnityEngine;
using System.Collections;

public class Activar_canvas : MonoBehaviour {

		public Canvas CanvasObject; // Assign in inspector
		
		void Update() 
		{
				CanvasObject.enabled = ComportamientoPatron.leon_en_escena;
			
		}
	}