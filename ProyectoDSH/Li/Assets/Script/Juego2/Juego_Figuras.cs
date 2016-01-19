using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Juego_Figuras : MonoBehaviour { 
	
	private int r1,r2,r3,patron;
	private static int[] vector_figuras = new int[6];
	static GameObject  circulo, triangulo, cuadrado, interrogacion;
	public Canvas canvas;
	public Text pregunta;
	public Text acertado;
	public static bool tocarboton;
	public static int boton_elegido;
	private float timeToStart=0;
	private float TiempoAntesDeAccion=2;
	private bool resultado_activo = false;
	private bool tocado_espera = false;

	void Start()
	{
		//Poner a false las figuras
		for (int i = 0; i< 6; ++i) 
		{
			circulo = canvas.transform.FindChild ("Circulo"+i).gameObject;
			circulo.SetActive(false);
			triangulo = canvas.transform.FindChild ("Triangulo"+i).gameObject;
			triangulo.SetActive(false);
			cuadrado = canvas.transform.FindChild ("Cuadrado"+i).gameObject;
			cuadrado.SetActive(false);
		}

		interrogacion = canvas.transform.FindChild ("Interrogacion").gameObject;
		interrogacion.SetActive(false);

		/*Figuras*/
		r1 = Random.Range (0, 3);
		r2 = Random.Range (0, 3);
		r3 = Random.Range (0, 3);
		
		/*Patron aleatorio*/
		patron = Random.Range (0, 3);
		
		pregunta.text = ("¿Que figura falta?");
		pregunta.gameObject.SetActive (false);

		while(r1==r2 || r2==r3 || r3==r1) 
		{
			r2 = Random.Range (0, 3);
			r3 = Random.Range (0, 3);
		}
		
		switch (patron) {
		case 0:
			patron_par(r1,r2,vector_figuras);break;
			
		case 1:
			patron_alternar(r1,r2,vector_figuras);break;
			
		case 2:
			patron_tres(r1,r2,r3,vector_figuras);break;
			
		default:
			patron_par(r1,r2,vector_figuras);break;
		}
	
	}
	
	/*El vector resultante tendra las posiciones pares con una figura y las impares con otra*/
	public void patron_par(int r1,int r2, int[] vector_figuras)
	{
		int i=0;
		while (i<5) 
		{
			vector_figuras[i]= r1;
			i+=2;
		}
		
		i = 1;
		while (i<=3)
		{
			vector_figuras[i]= r2;
			i+=2;
		}
		vector_figuras [5] = r2;
	}
	
	/*El vector resultantes va alternando de dos en dos figuras*/
	public void patron_alternar(int r1,int r2, int[] vector_figuras)
	{
		int i=0;
		bool alternar = true;
		
		while (i<5) 
		{
			if(alternar){
				vector_figuras[i]= r1;
				++i;
				vector_figuras[i]= r1;
				alternar = false;
			}
			else
			{
				vector_figuras[i]= r2;
				++i;
				vector_figuras[i]= r2;
				alternar = true;
			}
			i++;
		}
		vector_figuras [5] = r1;
	}
	
	/*El vector resultante es simetrico 123123*/
	public void patron_tres(int r1,int r2,int r3, int[] vector_figuras)
	{
		vector_figuras [0] = r1;
		vector_figuras [1] = r2;
		vector_figuras [2] = r3;
		
		vector_figuras [3] = r1;
		vector_figuras [4] = r2;
		vector_figuras [5] = r3;
		
	}
	
	/*Traduce dada una figura elegida y la posicion que ocupa en el vector_figuras a figura grafica en el canvas  */
	
	public void traducir_figura (int[] vector_figuras )
	{		
		for (int i=0; i<5; i++) 
		{
			switch (vector_figuras[i]) 
			{
			case 0:
				circulo = canvas.transform.FindChild ("Circulo"+i).gameObject;
				circulo.SetActive(true);
				break;
			case 1:
				cuadrado = canvas.transform.FindChild ("Cuadrado"+i).gameObject;
				cuadrado.SetActive(true);
				break;
			case 2:
				triangulo = canvas.transform.FindChild ("Triangulo"+i).gameObject;
				triangulo.SetActive(true);
				break;
			}
		}
		
		interrogacion = canvas.transform.FindChild ("Interrogacion").gameObject;
		interrogacion.SetActive(!resultado_activo);

	}

	void inicializar()
	{
		//Poner a false las figuras
		for (int i = 0; i< 6; ++i) 
		{
			circulo = canvas.transform.FindChild ("Circulo"+i).gameObject;
			circulo.SetActive(false);
			triangulo = canvas.transform.FindChild ("Triangulo"+i).gameObject;
			triangulo.SetActive(false);
			cuadrado = canvas.transform.FindChild ("Cuadrado"+i).gameObject;
			cuadrado.SetActive(false);
		}

		interrogacion = canvas.transform.FindChild ("Interrogacion").gameObject;
		interrogacion.SetActive(false);
	}

	private IEnumerator delayFuegos()
	{
		ControlTarget.fuegos2 = true;
		yield return new WaitForSeconds(2.0f);
	}
	
	private void Mostrar_Fuegos()
	{
		StartCoroutine(delayFuegos());
	}

	void Update()
	{

		if (ControlTarget.presencia_figuras) {

			pregunta.gameObject.SetActive (true);
			traducir_figura(vector_figuras);
		

		} else {
			pregunta.gameObject.SetActive (false);
			inicializar();

		}

		timeToStart += Time.deltaTime;

		if (tocarboton) 
		{
			timeToStart =0;
			inicializar();
			tocarboton = false;
			tocado_espera = true;

			/*Figuras*/
			if(vector_figuras [5] == boton_elegido)	
			{
				acertado.text = "¡Has acertado!";

				interrogacion = canvas.transform.FindChild ("Interrogacion").gameObject;
				interrogacion.SetActive(false);

				Mostrar_Fuegos();
				if (ControlTarget.currentFelicidad < 100)
					ControlTarget.currentFelicidad += 1;

				ControlTarget.score ++;
				if(ControlTarget.score == 5){
					ControlTarget.nChuletas ++;	
					ControlTarget.score = 0;
				}

				switch(boton_elegido)
				{
				case 0:
					circulo = canvas.transform.FindChild ("Circulo5").gameObject;
					circulo.SetActive(true);
					break;
				case 1:
					cuadrado = canvas.transform.FindChild ("Cuadrado5").gameObject;
					cuadrado.SetActive(true);
					break;
				case 2:
					triangulo = canvas.transform.FindChild ("Triangulo5").gameObject;
					triangulo.SetActive(true);
					break;
				}
				resultado_activo = true;

			}
			else{
				acertado.text ="¡Has fallado!";
				interrogacion = canvas.transform.FindChild ("Interrogacion").gameObject;
				interrogacion.SetActive(false);
				
				switch(boton_elegido)
				{
				case 0:
					circulo = canvas.transform.FindChild ("Circulo5").gameObject;
					circulo.SetActive(true);
					break;
				case 1:
					cuadrado = canvas.transform.FindChild ("Cuadrado5").gameObject;
					cuadrado.SetActive(true);
					break;
				case 2:
					triangulo = canvas.transform.FindChild ("Triangulo5").gameObject;
					triangulo.SetActive(true);
					break;
				}
				resultado_activo = true;

			}
		}

		if (timeToStart >= TiempoAntesDeAccion && tocado_espera )
		{			
			resultado_activo = false;
			tocado_espera = false;

			r1 = Random.Range (0, 3);
			r2 = Random.Range (0, 3);
			r3 = Random.Range (0, 3);

			/*Patron aleatorio*/
			patron = Random.Range (0, 3);
			
			while(r1==r2 || r2==r3 || r3==r1) 
			{
				r2 = Random.Range (0, 3);
				r3 = Random.Range (0, 3);
			}
			
			switch (patron) {
			case 0:
				patron_par (r1, r2, vector_figuras);
				break;
				
			case 1:
				patron_alternar (r1, r2, vector_figuras);
				break;
				
			case 2:
				patron_tres (r1, r2, r3, vector_figuras);
				break;
				
			default:
				patron_par (r1, r2, vector_figuras);
				break;
			}
			acertado.text = "";
			inicializar();
			traducir_figura(vector_figuras);
			timeToStart=0;
		}
	}






}