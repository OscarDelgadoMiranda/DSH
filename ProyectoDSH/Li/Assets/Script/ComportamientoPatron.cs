using UnityEngine;
using System.Collections;

public class ComportamientoPatron : MonoBehaviour
{
	// Public variables
	public GameObject[] HitosPatronMovimiento;
	public float[] VelocidadesPatronMovimiento;
	private Vector3 rotacion;
	public Transform target_comida; 
	public Transform target_bebida; //el Objetivo
	public float moveSpeed = 3; //velocidad de movimiento
	public float rotationSpeed = 3; //Velocidad de rotación
	public Transform myTransform;
	public static int operacion = 0;
	public static bool t_comida;
	public static bool t_bebida;
	public static bool leon_en_escena = false;
	public Animator ani;
	public float velocidadDeAnimacion;//Solo si tu objeto esta animado
	
	// Private variables
	private Transform thisTransform;
	private int HitoSiguiente = 0;
	private float timeToStart;
	private Rigidbody rb;
	private float TiempoAntesDeAccion;
	private int cont_comida=0;
	private int cont_bebida=5;
	public bool com_beb;
	public bool comido;
	int cont;
	// Properties
	// Nos indicará si el objeto puede continuar hacia el siguiente hito del patrón definido
	public bool CanGoToNextMilestone { get; set; }
	
	
	void Start () 
	{
		ani = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		velocidadDeAnimacion = moveSpeed*0.3f;
		thisTransform = transform;
		CanGoToNextMilestone = true;
		HitoSiguiente = 0; //Tenemos que empezar por el primer hito
		timeToStart = 0;
		TiempoAntesDeAccion= 3;
		com_beb = false;
		comido = false;
		
	}
	
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) //En el caso de salirnos guardamos los estados de las barras
		{
			Guardado.Grabar();
			Application.LoadLevel("Menu");
		}
		
		if (cont_comida <= 0) {

			if(ControlTarget.nChuletas>0){
				cont_comida=5;
				if(cont==1){
				ControlTarget.nChuletas--;
				}else{
					cont++;
				}

			}

			t_comida=false;
			target_comida.gameObject.SetActive(false);
			target_comida.localScale = new Vector3(0.05f,0.05f,0.05f);
		}
		if (cont_bebida <= 0) {
			cont_bebida=5;
			t_bebida=false;
			target_bebida.gameObject.SetActive(false);
			target_bebida.localScale = new Vector3(0.078f,0.02001f,0.078f);
		}
		
		if (!t_comida && !t_bebida && com_beb ) {
			ani.Play ("Li_Run");
			com_beb = false;
			
		}
		if (!t_comida && !t_bebida && !ControlTarget.presencia_numeros) 
			Libre ();
		else if (t_comida && ControlTarget.nChuletas>0) {
			if (!target_comida.gameObject.activeSelf)
				target_comida.gameObject.SetActive (true);
			Comer ();
		} else if (t_bebida ){
			if (!target_bebida.gameObject.activeSelf)
				target_bebida.gameObject.SetActive (true);
			Beber ();
		}
		
		
	}
	
	public void Libre(){
		// Calculamos la velocidad hacia el siguiente hito (si no hubiese velocidad definida para
		// alguno de los hitos, asumiremos que es 0 y por tanto el objeto quedará parado)
		float VelocidadHaciaHito = 0;
		try {
			VelocidadHaciaHito = VelocidadesPatronMovimiento [HitoSiguiente];
			
		} catch {
			VelocidadHaciaHito = 0;
		}
		
		// Comprobamos si podemos ir hacia el siguiente hito
		if (CanGoToNextMilestone) {
			try {
				// Movemos al objeto hacia el siguiente hito
				if (IrHaciaHito (HitosPatronMovimiento [HitoSiguiente].transform.position, VelocidadHaciaHito)) {
					// Justo cuando lleguemos a un hito, paramos al objeto
					CanGoToNextMilestone = false;
					
					// Activamos el/los script/s de comportamiento correspondiente/s al hito actual (los que
					// su nombre empiecen contengan la palabra 'Patron').
					bool patronFound = false;
					MonoBehaviour[] milestoneScripts = HitosPatronMovimiento [HitoSiguiente].GetComponents<MonoBehaviour> ();
					foreach (MonoBehaviour script in milestoneScripts) {
						if (script.GetType ().Name.Contains ("Patron")) {
							patronFound = true;
							script.enabled = true;
						}
					}
					
					// Si no encontramos ningún script de comportamiento en el hito, continuamos al siguiente
					if (!patronFound) {
						CanGoToNextMilestone = true;
					}

					//El sigueinte hito sera buscado de forma aleatoria entre todos los que hay definidos
					HitoSiguiente = Random.Range (0, HitosPatronMovimiento.Length); 
				}
			} catch {
				HitoSiguiente = Random.Range (0, HitosPatronMovimiento.Length);
			}
		}
	}
	public void Comer(){
		if (target_comida.position.x <= rb.position.x+0.5 && target_comida.position.x >= rb.position.x-0.5 
		    && target_comida.position.y <= rb.position.y+0.5 && target_comida.position.y >= rb.position.y-0.5
		    && target_comida.position.z <= rb.position.z+0.5 && target_comida.position.z >= rb.position.z-0.5) 
		{
			
			rb.velocity = new Vector3 (0, 0, 0);
			rb.angularVelocity = new Vector3 (0, 0, 0);
			com_beb = true;
			
			if(cont_comida>0)
			{
				timeToStart += Time.deltaTime;
				
				// No realizamos la acción hasta que no pase el tiempo 'TiempoAntesDeAccion'
				ani.Play("Li_Eat");
				
				if (timeToStart >= TiempoAntesDeAccion)
				{				
					ani.Play("Li_Run");
					if(leon_en_escena){
						target_comida.localScale = new Vector3(target_comida.localScale.x-0.01f,target_comida.localScale.y-0.01f,target_comida.localScale.z-0.01f);
						int i = 0;
						while(ControlTarget.currentHambre <=100 && i<=20){
							ControlTarget.currentHambre ++;
							i++;
						}
						cont_comida--;
					}
					timeToStart=0;
				}
			}
		}
		else
		{
			ani.Play("Li_Run");
			//Rotacion para mirar hacia el target(objetivo a seguir)
			myTransform.rotation = Quaternion.Lerp (myTransform.rotation, Quaternion.LookRotation (target_comida.position - myTransform.position), rotationSpeed* Time.deltaTime);
			//Movimiento en dirección del target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
	
	public void Beber(){
		
		if (target_bebida.position.x <= rb.position.x+0.5 && target_bebida.position.x >= rb.position.x-0.5 
		    && target_bebida.position.y <= rb.position.y+0.5 && target_bebida.position.y >= rb.position.y-0.5
		    && target_bebida.position.z <= rb.position.z+0.5 && target_bebida.position.z >= rb.position.z-0.5) 
		{
			
			rb.velocity = new Vector3 (0, 0, 0);
			rb.angularVelocity = new Vector3 (0, 0, 0);
			
			com_beb = true;
			if(cont_bebida>0)
			{
				timeToStart += Time.deltaTime;
				// No realizamos la acción hasta que no pase el tiempo 'TiempoAntesDeAccion'
				ani.Play("Li_Drink");
				
				if (timeToStart >= TiempoAntesDeAccion)
				{	
					ani.Play ("Li_Run");		
					if(leon_en_escena){

						if(target_bebida.localScale.y>0.0001)
							target_bebida.localScale = new Vector3(target_bebida.localScale.x,target_bebida.localScale.y-0.01f,target_bebida.localScale.z);
						else 
							target_bebida.localScale = new Vector3(target_bebida.localScale.x-0.026f,target_bebida.localScale.y,target_bebida.localScale.z-0.026f);
						int i=0;
						while(ControlTarget.currentSed <=100 && i<=20){
							ControlTarget.currentSed ++;
							i++;
						}
						cont_bebida--;
					}
					timeToStart=0;
				}
			}
		}
		else
		{
			ani.Play("Li_Run");
			//Rotacion para mirar hacia el target(objetivo a seguir)
			myTransform.rotation = Quaternion.Lerp (myTransform.rotation, Quaternion.LookRotation (target_bebida.position - myTransform.position), rotationSpeed* Time.deltaTime);
			//Movimiento en dirección del target
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			
		}
	}
	
	private bool IrHaciaHito(Vector3 PosicionHito, float Velocidad)
	{
		// Calculamos la distancia entre el hito y el objeto
		Vector3 VectorHaciaObjetivo = PosicionHito - thisTransform.position;
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
			thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation,Quaternion.LookRotation((PosicionHito - thisTransform.position)),3*Time.deltaTime);
			
			// Movemos el objeto hacia el hito
			thisTransform.position += thisTransform.forward * Velocidad * Time.deltaTime;
			// El objeto aún no ha llegado al hito
			return false;
		}
		else
		{
			// El objeto ha llegado al hito
			return true;
		}
	}
	
	public void Awake()
	{
		myTransform = transform; 
	}
	
}
