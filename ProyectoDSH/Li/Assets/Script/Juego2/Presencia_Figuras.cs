using UnityEngine;
using System.Threading;
using System.Collections;
using Vuforia;

public class Presencia_Figuras : MonoBehaviour, ITrackableEventHandler {
	
	private TrackableBehaviour mTrackableBehaviour;
	void Start () 
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			ControlTarget.presencia_figuras = true; /*Si el leon esta presente lo notifica a ComportamientoPatron*/
			
		}
		else
		{
			ControlTarget.presencia_figuras = false;
		}
		
	}
}
