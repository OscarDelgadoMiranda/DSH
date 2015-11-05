using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pelota : MonoBehaviour 
{
	private Rigidbody rigibody;
	private int velocidad = 1500;
	public float temporizador;
	public static double temporizadorDouble;
    public static int tiempoArestar;
    public static int destruidosF;
    public static int tiempoF;
	public Text tiempo;

	// Use this for initialization
	void Start () 
	{
		temporizador = SceneManager.tiempo;
		rigibody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		temporizador += Time.deltaTime;
		temporizadorDouble = (double)temporizador;
		tiempo.text = "Tiempo: " + temporizadorDouble.ToString("F2") + " segundos";
        tiempoArestar = (int)temporizadorDouble;
		SceneManager.tiempo = tiempoArestar;
	}

	void FixedUpdate ()
	{
		float horizontal = -Input.GetAxis ("Horizontal");
		float vertical = -Input.GetAxis ("Vertical");
		
		Vector3 movimiento = new Vector3 (horizontal, 0, vertical);
		
		rigibody.AddForce (movimiento * velocidad * Time.deltaTime);
	}
}