using UnityEngine;
using System.Collections;
using UnityEngine.UI;
	
public class Juego_Suma : MonoBehaviour { 
		
		private int r1,r2,resultado,boton_seleccionado,aux1,aux2;
		public Text animos;
		public Text boton1;
		public Text boton2;
		public Text boton3;
		public Text pregunta;
		public static bool tocarboton;
		public static int boton_elegido;

		void Start()
		{
			r1 = Random.Range (1, 6);
			r2 = Random.Range (1, 6);
			boton_seleccionado = Random.Range (1,4);
			resultado = r1 + r2;
			pregunta.text = (r1+" + "+r2+"  =  ?");
			
			aux1 = aux2 = resultado;
			while(aux1 == aux2 || aux1==resultado || aux2==resultado) 
			{
				aux1 = Random.Range (1, 6);
				aux2 = Random.Range (1, 6);
			}

			switch (boton_seleccionado) {
			case 1:
				boton1.text = resultado.ToString ();
				boton2.text = aux1.ToString ();
				boton3.text = aux2.ToString ();
				break;
				
			case 2:
				boton1.text = aux1.ToString ();
				boton2.text = resultado.ToString ();
				boton3.text = aux2.ToString ();
				break;
				
			case 3:
				boton1.text = aux1.ToString ();
				boton2.text = aux2.ToString ();
				boton3.text = resultado.ToString ();
				break;
			}
		}
		
		void Update()
		{
			if (tocarboton) {
				tocarboton = false;
				if (boton_elegido == boton_seleccionado)
				{
					verMensajeAcierto();
					ControlTarget.fuegos = true;
					if (ControlTarget.currentFelicidad < 100)
						ControlTarget.currentFelicidad += 1;

					ControlTarget.score ++;
					if(ControlTarget.score == 5){
						ControlTarget.nChuletas ++;

						ControlTarget.score = 0;
				}
			}
				else
					verMensajeFallo();
				
				r1 = Random.Range (1, 6);
				r2 = Random.Range (1, 6);
				
				resultado = r1 + r2;
				pregunta.text = (r1 + " + " + r2 + "  =  ?");
				
				aux1 = aux2 = resultado;
				while (aux1 == aux2 || aux1==resultado || aux2==resultado) {
					aux1 = Random.Range (1, 6);
					aux2 = Random.Range (1, 6);
				}
				
				boton_seleccionado = Random.Range (1, 4);
				switch (boton_seleccionado) {
				case 1:
					boton1.text = resultado.ToString ();
					boton2.text = aux1.ToString ();
					boton3.text = aux2.ToString ();
					break;
					
				case 2:
					boton1.text = aux1.ToString ();
					boton2.text = resultado.ToString ();
					boton3.text = aux2.ToString ();
					break;
					
				case 3:
					boton1.text = aux1.ToString ();
					boton2.text = aux2.ToString ();
					boton3.text = resultado.ToString ();
					break;
				}
			} 	
		}
		
		//Funcion de pregunta acertada
		private void verMensajeAcierto()
		{
			StartCoroutine(delayAcierto());
		}
		
		//Funcion de pregunta fallada
		private void verMensajeFallo()
		{
			StartCoroutine(delayFallo());
		}
		
		//Corrutina para la duracion del mensaje de acierto
		private IEnumerator delayAcierto()
		{
			animos.text = ("¡Has acertado!");
			yield return new WaitForSeconds(2.0f);
			animos.text = ("");
		}
		
		//Corrutina para la duracion del mensaje de fallo
		private IEnumerator delayFallo()
		{
			animos.text = ("¡Intentalo de nuevo!");
			yield return new WaitForSeconds(2.0f);
			animos.text = ("");
		}
	}