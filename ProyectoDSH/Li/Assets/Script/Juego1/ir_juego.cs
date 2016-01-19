using UnityEngine;
using System.Threading;
using System.Collections;
using Vuforia;

public class ir_juego : MonoBehaviour
{
	// Public variables
	public Animator ani;
	private Vector3 rotacion;
	public Transform target_numero; //el Objetivo
	public float moveSpeed = 3; //velocidad de movimiento
	public float rotationSpeed = 3; //Velocidad de rotación
	public Transform myTransform;
	public float velocidadDeAnimacion;//Solo si tu objeto esta animado
	public Rigidbody rb;
	
	// Private variables

	// Properties
	// Nos indicará si el objeto puede continuar hacia el siguiente hito del patrón definido

	void Update ()
	{

		if (ControlTarget.presencia_numeros && !ComportamientoPatron.t_comida && !ComportamientoPatron.t_bebida) {

			jugar();
		} 
		
		
	}
	

	
	public void jugar(){
		
		if (target_numero.position.x <= rb.position.x + 0.5 && target_numero.position.x >= rb.position.x - 0.5 
			&& target_numero.position.y <= rb.position.y + 0.5 && target_numero.position.y >= rb.position.y - 0.5
			&& target_numero.position.z <= rb.position.z + 0.5 && target_numero.position.z >= rb.position.z - 0.5) {
			moveSpeed = 1;
			rb.velocity = new Vector3 (0, 0, 0);
			rb.angularVelocity = new Vector3 (0, 0, 0);
			ani.Play("Li_Idle");
		}else{
			ani.Play("Li_Run");
			//Rotacion para mirar hacia el target(objetivo a seguir)
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target_numero.position - myTransform.position), rotationSpeed* Time.deltaTime);
			//Movimiento en dirección del target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			
		}
	}
	

	
	public void Awake()
	{
		myTransform = transform; 
	}
	
}



	
