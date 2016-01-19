/*============================================================================== 
 * Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/

using UnityEngine;
using System.Collections.Generic;
using Vuforia;

/// <summary>
/// This class implements the IVirtualButtonEventHandler interface and
/// contains the logic to swap materials for the teapot model depending on what 
/// virtual button has been pressed.
/// </summary>
public class BotonesVirtuales : MonoBehaviour, IVirtualButtonEventHandler,  ITrackableEventHandler
{
	#region PUBLIC_MEMBER_VARIABLES
	
	/// <summary>
	/// The materials that will be set for the teapot model
	/// </summary>
	//public Material[] m_TeapotMaterials;
	
	#endregion // PUBLIC_MEMBER_VARIABLES
	
	
	
	#region PRIVATE_MEMBER_VARIABLES
	//Leon
	public GameObject Li;
	//Objetos vacias, direccion a la que se girar el leon
	private GameObject giroIzquierda;
	private GameObject giroDerecha;
	private GameObject giroFrente;
	private GameObject giroAtras;
	//Necesario para guardar los botones virtuales
	private TrackableBehaviour mTrackableBehaviour;
	//objeto para reproducir las animaciones
	private Animator Li_animacion;
	//variable con el estado de animo del leon
	private bool enfadado;
	
	#endregion // PRIVATE_MEMBER_VARIABLES
	
	
	
	#region UNITY_MONOBEHAVIOUR_METHODS
	
	void Start()
	{
		// Register with the virtual buttons TrackableBehaviour
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; ++i)
		{
			vbs[i].RegisterEventHandler(this);
		}
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

		//obtenemos los objetos
		giroIzquierda = transform.FindChild ("Girar_Izquierda").gameObject;
		giroDerecha = transform.FindChild ("Girar_Derecha").gameObject;
		giroFrente = transform.FindChild ("Girar_Frente").gameObject;
		giroAtras = transform.FindChild ("Girar_Atras").gameObject;
		//componente para la animacion
		Li_animacion = Li.GetComponent<Animator>();
		enfadado = false;
		Li.GetComponent<IrCentro>().enabled = false;//desactivamos este script para pasar al modo de tocar el leon
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){ //check if escape key is pressed
			
			Application.LoadLevel (0);
		}
		if (ControlTarget.currentFelicidad <= 25 || ControlTarget.currentSed <= 25 || ControlTarget.currentHambre <=25)
		{
			enfadado = true;
		} 
		else 
		{
			enfadado = false;
		}
		/*Dubai.GetComponent<Rigidbody> ().transform.Rotate (new Vector3 (0, Dubai.GetComponent<Rigidbody> ().rotation.y + 1,0 ));
		Big_Ben.GetComponent<Rigidbody> ().transform.Rotate (new Vector3 (0, Big_Ben.GetComponent<Rigidbody> ().rotation.y + 1,0));
		Turning_Torso.GetComponent<Rigidbody> ().transform.Rotate (new Vector3 (0, Turning_Torso.GetComponent<Rigidbody> ().rotation.y + 1, 0));*/
	}
	
	#endregion // UNITY_MONOBEHAVIOUR_METHODS
	
	
	
	#region PUBLIC_METHODS
	
	/// <summary>
	/// Called when the virtual button has just been pressed:
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			Debug.Log ("Detectado" );
		}
		else
		{
			Debug.Log ("no detectado" );

		}
		
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{

		if (ControlTarget.tocar == true) 
		{

			Li_animacion = Li.GetComponent<Animator>();
			
			//frente del leon(en la imagen target las patas del dibujo)
			if (vb.VirtualButtonName == "VB3_3" || vb.VirtualButtonName == "VB4_3")
			{
				//de fernte
				Li.transform.rotation = Quaternion.LookRotation((giroFrente.transform.position - Li.transform.position));
				if(enfadado == false)
				{
					Li_animacion.Play("Li_Drink");
					if(ControlTarget.currentFelicidad +1 == 100)
					{
						ControlTarget.currentFelicidad = 100;
					}
					else
					{
						ControlTarget.currentFelicidad += 1;
					}
				}
				else
				{
					Li_animacion.PlayInFixedTime("Li_Attack");
				}
				
			}
			//espalda del leon(en la imagen target arriba de la figura)
			if (vb.VirtualButtonName == "VB2_3" || vb.VirtualButtonName == "VB1_3")
			{
				//de fernte
				Li.transform.rotation = Quaternion.LookRotation((giroAtras.transform.position - Li.transform.position));
				if(enfadado == false)
				{
					Li_animacion.Play("Li_Drink");
					if(ControlTarget.currentFelicidad +1 == 100)
					{
						ControlTarget.currentFelicidad = 100;
					}
					else
					{
						ControlTarget.currentFelicidad += 1;
					}
				}
				else
				{
					Li_animacion.PlayInFixedTime("Li_Attack");
				}
				
			}
			
			
			//izquierda del leon
			if(vb.VirtualButtonName == "VB1_1" || vb.VirtualButtonName == "VB1_2" ||
			   vb.VirtualButtonName == "VB4_2" || vb.VirtualButtonName == "VB4_1")
			{
				//nos giramos
				Li.transform.rotation = Quaternion.LookRotation((giroIzquierda.transform.position - Li.transform.position));
				//comprobamos el animo del leon y hacemos una animacion respecto a como este
				if(enfadado == false)
				{
					Li_animacion.Play("Li_Drink");
					if(ControlTarget.currentFelicidad +1 == 100)
					{
						ControlTarget.currentFelicidad = 100;
					}
					else
					{
						ControlTarget.currentFelicidad += 1;
					}
				}
				else
				{
					Li_animacion.PlayInFixedTime("Li_Attack");
				}
				
			}
			//derecha del leon
			if (vb.VirtualButtonName == "VB2_1" || vb.VirtualButtonName == "VB2_2" ||
			    vb.VirtualButtonName == "VB3_1" || vb.VirtualButtonName == "VB3_2")
			{
				Li.transform.rotation = Quaternion.LookRotation((giroDerecha.transform.position - Li.transform.position));
				//comprobamos el animo del leon y hacemos una animacion respecto a como este
				if(enfadado == false)
				{
					Li_animacion.Play("Li_Drink");
					if(ControlTarget.currentFelicidad +1 == 100)
					{
						ControlTarget.currentFelicidad = 100;
					}
					else
					{
						ControlTarget.currentFelicidad += 1;
					}
				}
				else
				{
					Li_animacion.PlayInFixedTime("Li_Attack");
				}
			}
		}//fin if
	}//fin metodo
	
	
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{
		if (ControlTarget.tocar == true) 
		{
			Li_animacion.PlayInFixedTime("Li_Idle");
		}

	}
	
	
	private bool IsValid()
	{
		
		return false;
	}
	
	#endregion // PUBLIC_METHODS
}

