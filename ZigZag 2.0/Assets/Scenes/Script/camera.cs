using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour 
{
	public GameObject pelota;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position;
	
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = pelota.transform.position + offset;
	}
}
