using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FelicidadBar : MonoBehaviour
{
    public RectTransform FelicidadTransform;
    private float cachedY;
	private float minXValue;
	private float maxXValue;
	//private int currentFelicidad;
	void Update(){
		CurrentFelicidad = ControlTarget.currentFelicidad;
	}
	private int CurrentFelicidad
    {
        get { return ControlTarget.currentFelicidad; }
        set
        {
			ControlTarget.currentFelicidad = value;
            HandleFelicidad();
        }
    }

    public int maxFelicidad;
    public Image visualFelicidad;

    void Start()
    {
        //Guardamos las coordenadas iniciales de la barra y donde acaba
        cachedY = FelicidadTransform.position.y;
        maxXValue = FelicidadTransform.position.x;
        minXValue = FelicidadTransform.position.x + FelicidadTransform.rect.width;
		ControlTarget.currentFelicidad = maxFelicidad;

        //Llamada a la funcion que inicia el descenso progresivo por tiempo de la barra
        DescensoFelicidad();
    }
 
    //Funcion que modifica el color de la barra en funcion de su ubicacion
	private void HandleFelicidad()
    {
		float currentXValue = MapValues(ControlTarget.currentFelicidad, 0, maxFelicidad, minXValue, maxXValue);

        FelicidadTransform.position = new Vector3(currentXValue, cachedY);

		if (ControlTarget.currentFelicidad < maxFelicidad / 2) //Mas del 50%
        {
			visualFelicidad.color = new Color32(255, (byte)MapValues(ControlTarget.currentFelicidad, 0, maxFelicidad / 2, 0, 255), 0, 255);
        }
        else //Menos del 50%
        {
			visualFelicidad.color = new Color32((byte)MapValues(ControlTarget.currentFelicidad, maxFelicidad / 2, maxFelicidad, 255, 0), 255, 0, 255);
        }
    }

    //Funcion que mapea las coordenadas (divide en porciones iguales lo que aumenta/disminuye la barra)
	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    //Funcion que inicia las corrutinas cruzadas que hacen disminuir la barra
	private void DescensoFelicidad()
    {
        StartCoroutine(DF1());
    }

    //Corrutina 1
	private IEnumerator DF1()
    {
       

		if (CurrentFelicidad != 0 && ComportamientoPatron.leon_en_escena)
			CurrentFelicidad -= 1;
		yield return new WaitForSeconds(2.0f);
        StartCoroutine(DF2());
    }

    //Corrutina 2
	private IEnumerator DF2()
    {
        

		if (CurrentFelicidad != 0 && ComportamientoPatron.leon_en_escena)
			CurrentFelicidad -= 1;
		yield return new WaitForSeconds(2.0f);
        StartCoroutine(DF1());
    }
}