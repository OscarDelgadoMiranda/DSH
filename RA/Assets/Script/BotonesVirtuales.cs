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
public class BotonesVirtuales : MonoBehaviour,
IVirtualButtonEventHandler, ITrackableEventHandler
{
	#region PUBLIC_MEMBER_VARIABLES
	
	/// <summary>
	/// The materials that will be set for the teapot model
	/// </summary>
	//public Material[] m_TeapotMaterials;
	
	#endregion // PUBLIC_MEMBER_VARIABLES
	
	
	
	#region PRIVATE_MEMBER_VARIABLES
	
	//private GameObject mTeapot;
	private GameObject mLuz1, mLuz2, Luz;
	private GameObject Big_Ben;
	private GameObject Turning_Torso;
	private GameObject Dubai;
	
	public GameObject cDubai;
	public GameObject cBig;
	public GameObject cTurning;
	
	private static int cont=0;
	private static bool detectado=false;
	private TrackableBehaviour mTrackableBehaviour;
	
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
		//Se obtienen los objetos;
		mLuz1 = transform.FindChild("Luz1").gameObject;
		mLuz2 = transform.FindChild("Luz2").gameObject;
		Luz = transform.FindChild("LuzCentral").gameObject;
		
		Dubai = transform.FindChild ("Burj+Dubai").gameObject;
		Big_Ben = transform.FindChild ("bigben+blow+up").gameObject;
		Turning_Torso = transform.FindChild ("turning+torso").gameObject;	

	}
	
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){ //check if escape key is pressed
			
			Application.LoadLevel (0);
			
		}
		Dubai.GetComponent<Rigidbody> ().transform.Rotate (new Vector3 (0, Dubai.GetComponent<Rigidbody> ().rotation.y + 1,0 ));
		Big_Ben.GetComponent<Rigidbody> ().transform.Rotate (new Vector3 (0, Big_Ben.GetComponent<Rigidbody> ().rotation.y + 1,0));
		Turning_Torso.GetComponent<Rigidbody> ().transform.Rotate (new Vector3 (0, Turning_Torso.GetComponent<Rigidbody> ().rotation.y + 1, 0));
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
			detectado=true;
			Dubai.SetActive (true);
			Turning_Torso.SetActive (false);
			cDubai.SetActive (true);
			Debug.Log ("Detectado" );
		}
		else
		{
			detectado=false;
			Debug.Log ("no detectado" );
			cDubai.SetActive (false);
			cBig.SetActive (false);
			cTurning.SetActive (false);
			}

	}
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		Debug.Log ("OnButtonPressed::" + vb.VirtualButtonName);
		
		switch (vb.VirtualButtonName) {
			
		case "off":
			mLuz1.GetComponent<Light> ().intensity = 0;
			mLuz2.GetComponent<Light> ().intensity = 0;
			Luz.GetComponent<Light> ().intensity = 0;	
			break;
		case "on":
			mLuz1.GetComponent<Light> ().intensity = 8;
			mLuz2.GetComponent<Light> ().intensity = 8;
			Luz.GetComponent<Light> ().intensity = 1.75f;
			break;
		case "Der":
			if(cont+1<=2){
				
				cont++;
				
			}else if(cont ==2){
				cont =0;
			}
			break;
		case "Izq":
			if(cont-1>=0){
				
				cont--;
				
			}else if(cont ==0){
				cont =2;
			}
			break;
		}

		if (detectado) {
			switch (cont) {
			
			case 0:
				cDubai.SetActive (true);
				Dubai.SetActive (true);

				cTurning.SetActive (false);
				cBig.SetActive (false);
				Turning_Torso.SetActive (false);
				Big_Ben.SetActive (false);

				break;
			
			case 1:
			
				cTurning.SetActive (false);
				cDubai.SetActive (false);
				cBig.SetActive (true);
			
				Dubai.SetActive (false);
				Turning_Torso.SetActive (false);
				Big_Ben.SetActive (true);
			
				break;
			case 2:
			
				cDubai.SetActive (false);
				cBig.SetActive (false);
				cTurning.SetActive (true);
			
				Dubai.SetActive (false);
				Big_Ben.SetActive (false);
				Turning_Torso.SetActive (true);
				break;
			}

		
		} else {
			cDubai.SetActive (false);
			cBig.SetActive (false);
			cTurning.SetActive (false);
		}
		
	}

	
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{

	}
	
	
	private bool IsValid()
	{
		
		return false;
	}
	
	#endregion // PUBLIC_METHODS
}
