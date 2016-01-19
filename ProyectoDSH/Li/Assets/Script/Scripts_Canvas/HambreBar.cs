using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HambreBar : MonoBehaviour 
{
    public RectTransform HambreTransform;
    private float cachedY;
    private float minXValue;
    private float maxXValue;
	public Text tHambre;
    //private int currentHambre;
	public void Update(){

		tHambre.text = ControlTarget.nChuletas +"  Hambre" ;
		CurrentHambre = ControlTarget.currentHambre;
	}
    public int CurrentHambre
    {
        get { return ControlTarget.currentHambre; }
        set { 
			ControlTarget.currentHambre = value;
            HandleHambre();
        }
    }

    public int maxHambre;
    public Image visualHambre;

	void Start () 
    {
        //Guardamos las coordenadas iniciales de la barra y donde acaba
        cachedY = HambreTransform.position.y;
        maxXValue = HambreTransform.position.x;
        minXValue = HambreTransform.position.x - HambreTransform.rect.width;
		ControlTarget.currentHambre = maxHambre;
        
        //Llamada a la funcion que inicia el descenso progresivo por tiempo de la barra
        DescensoHambre();
	}


    //Funcion que modifica el color de la barra en funcion de su ubicacion
    private void HandleHambre()
    {
		float currentXValue = MapValues(ControlTarget.currentHambre, 0, maxHambre, minXValue, maxXValue);
        
        HambreTransform.position = new Vector3(currentXValue, cachedY);

		if (ControlTarget.currentHambre > maxHambre/2) //Mas del 50%
        {
			visualHambre.color = new Color32((byte)MapValues(ControlTarget.currentHambre,maxHambre/2,maxHambre,255,0), 255, 0, 255);
        }
        else //Menos del 50%
        {
			visualHambre.color = new Color32(255,(byte)MapValues(ControlTarget.currentHambre,0,maxHambre/2,0,255), 0, 255);
        }
    }

    //Funcion que mapea las coordenadas (divide en porciones iguales lo que aumenta/disminuye la barra)
    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    //Funcion que inicia las corrutinas cruzadas que hacen disminuir la barra
    private void DescensoHambre()
    {
        StartCoroutine(DH1());
    }

    //Corrutina 1
    private IEnumerator DH1()
    {
        yield return new WaitForSeconds(1.0f);

		if (CurrentHambre != 0 && ComportamientoPatron.leon_en_escena)
            CurrentHambre -= 1;

        StartCoroutine(DH2());
    }

    //Corrutina 2
    private IEnumerator DH2()
    {
        yield return new WaitForSeconds(1.0f);

		if (CurrentHambre != 0 && ComportamientoPatron.leon_en_escena)
            CurrentHambre -= 1;

        StartCoroutine(DH1());
    }
}
