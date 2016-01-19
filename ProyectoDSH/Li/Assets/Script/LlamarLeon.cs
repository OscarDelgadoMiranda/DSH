using UnityEngine;
using System.Collections;

public class LlamarLeon : MonoBehaviour 
{
	public GameObject Hito1;
	public GameObject Li;
	public GameObject imagentarget;
	public GameObject[] HitosPatronMovimiento;
	private int HitoSiguiente;
	private GameObject patronActual;
	private Animator Li_Animacion;
	void start()
	{
		Li_Animacion = Li.GetComponent<Animator>();
	}
	public void CallLi()
	{
		if (ControlTarget.llamar_leon == false) 
		{
			//El leon ha sido llamado
			Li.GetComponent<ComportamientoPatron>().enabled = false;
			DesactivarPatrones();
			ControlTarget.salirUpdate = false;
			Li.GetComponent<IrCentro>().enabled = true;
			ControlTarget.tocar = true;
			ControlTarget.llamar_leon = true;
		} 
		else 
		{
			ControlTarget.llamar_leon = false;
			ControlTarget.tocar = false;
			Li.GetComponent<IrCentro>().enabled = false;
			ActivarPatrones();
			Li.GetComponent<ComportamientoPatron>().enabled = true;
			
		}
	}


	public void DesactivarPatrones()
	{
		for (int HitoSiguiente = 0; HitoSiguiente <HitosPatronMovimiento.Length; HitoSiguiente++)
		{

			HitosPatronMovimiento[HitoSiguiente].SetActive(false);
		
		}
	}

	public void ActivarPatrones()
	{
		for (int HitoSiguiente = 0; HitoSiguiente <HitosPatronMovimiento.Length; HitoSiguiente++)
		{
			HitosPatronMovimiento[HitoSiguiente].SetActive(true);
		}
	}
}
