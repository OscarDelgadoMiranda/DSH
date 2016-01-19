using UnityEngine;
using System.Collections;

public class IrCentro : MonoBehaviour {

	public GameObject Li;
	public GameObject imagentarget;
	public GameObject Hito1;
	private Animator Li_Animacion;

	// Use this for initialization
	void Start () 
	{
		Li_Animacion = Li.GetComponent<Animator>();
		ControlTarget.salirUpdate = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ControlTarget.salirUpdate == false) 
		{
			if (IrHaciaObjetivo(Hito1.transform.position, 0.8f) == true) {

				Li_Animacion.Play ("Li_Idle");
				ControlTarget.salirUpdate = true;
				//imagentarget.GetComponent<BotonesVirtuales>().enabled = true;
			} else {
				Li_Animacion.Play ("Li_Walk");
			}
		}
		
	}




	private bool IrHaciaObjetivo(Vector3 PosicionHito, float Velocidad)
	{
		// Calculamos la distancia entre el hito y el objeto
		Vector3 VectorHaciaObjetivo = PosicionHito - Li.transform.position;
		// Si estamos en modo 'Terrestre', calculamos la distancia ignorando el eje Y
		VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 0, VectorHaciaObjetivo.z);
		
		// Con esta condición comprobamos si el objeto aún no ha llegado a las coordenadas del hito
		if (Mathf.Abs(VectorHaciaObjetivo.x) > 0.2F || Mathf.Abs(VectorHaciaObjetivo.y) > 0.2F || Mathf.Abs(VectorHaciaObjetivo.z) > 0.2F)
		{ 
			// Calculamos el vector de movimiento hacia el hito
			VectorHaciaObjetivo.Normalize();
			VectorHaciaObjetivo *= Velocidad;
			VectorHaciaObjetivo = new Vector3(VectorHaciaObjetivo.x, 
			                                  VectorHaciaObjetivo.y, 
			                                  VectorHaciaObjetivo.z);
			//apuntamos hacia el siguiente gito
			Li.transform.rotation = Quaternion.Slerp(Li.transform.rotation,Quaternion.LookRotation((PosicionHito - Li.transform.position)),3*Time.deltaTime);
			
			// Movemos el objeto hacia el hito
			Li.transform.position +=Li.transform.forward * Velocidad * Time.deltaTime;
			// El objeto aún no ha llegado al hito
			return false;
		}
		else
		{
			// El objeto ha llegado al hito
			return true;
		}
	}
}
