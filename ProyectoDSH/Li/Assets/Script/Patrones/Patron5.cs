using UnityEngine;
using System.Collections;

public class Patron5 : MonoBehaviour 
{
	// Public variables
	public GameObject Li;
	private Animator lion;
	public float TiempoAntesDeAccion;
	public float TiempoDespuesDeAccion;
	
	// Private variables
	private float timeToStart;
	private float timeToEnd;
	private bool workDone;
	
	
	void Start()
	{
		// Justo al inicio deshabilitamos el script (será activado por el script 
		// 'ComportamientoPatron.cs' cuando el objeto activador llegue al hito)
		this.enabled = false;
		lion = Li.GetComponent<Animator>();
		timeToStart = 0;
		timeToEnd = 0;
		workDone = false;
	}
	
	
	void Update()
	{
		if (!workDone)
		{
			timeToStart += Time.deltaTime;
			lion.PlayInFixedTime("Li_Attack");
			// No realizamos la acción hasta que no pase el tiempo 'TiempoAntesDeAccion'
			if (timeToStart >= TiempoAntesDeAccion)
			{
				lion.Play("Li_Idle");
				
				workDone = true;
			}
		}
		else
		{
			timeToEnd += Time.deltaTime;
			
			//No avanzamos al siguiente hito hasta que no pase el tiempo 'TiempoDespuesDeAccion'
			if (timeToEnd >= TiempoDespuesDeAccion)
			{
				// Se inicializa el script
				Start();
				lion.Play("Li_Walk");
				// Indicamos que se puede pasar el siguiente hito
				Li.GetComponentInParent<ComportamientoPatron>().CanGoToNextMilestone = true;
			}
		}
	}
	
	
}
