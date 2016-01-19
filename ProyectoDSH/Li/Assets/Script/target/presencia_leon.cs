using UnityEngine;
using System.Threading;
using System.Collections;
using Vuforia;

public class presencia_leon : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;

	void Start () {
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
			ComportamientoPatron.leon_en_escena=true; /*Si el leon esta presente lo notifica a ComportamientoPatron*/
			
		}
		else
		{
			ComportamientoPatron.leon_en_escena=false;
			
		}
		
	}
}
