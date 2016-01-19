using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SedBar : MonoBehaviour
{
    public RectTransform SedTransform;
    private float cachedY;
    private float minXValue;
    private float maxXValue;
    //private int currentSed;
	void Update(){
		CurrentSed = ControlTarget.currentSed;
	}
    public int CurrentSed
    {
        get { return ControlTarget.currentSed; }
        set
        {
			ControlTarget.currentSed = value;
            HandleSed();
        }
    }

    public int maxSed;
    public Image visualSed;

    void Start()
    {
        //Guardamos las coordenadas iniciales de la barra y donde acaba
        cachedY = SedTransform.position.y;
        maxXValue = SedTransform.position.x;
        minXValue = SedTransform.position.x - SedTransform.rect.width;
		ControlTarget.currentSed = maxSed;

        //Llamada a la funcion que inicia el descenso progresivo por tiempo de la barra
        DescensoSed();
    }
	
    //Funcion que modifica el color de la barra en funcion de su ubicacion
    private void HandleSed()
    {
		float currentXValue = MapValues(ControlTarget.currentSed, 0, maxSed, minXValue, maxXValue);

        SedTransform.position = new Vector3(currentXValue, cachedY);

		if (ControlTarget.currentSed > maxSed / 2) //Mas del 50%
        {
			visualSed.color = new Color32((byte)MapValues(ControlTarget.currentSed, maxSed / 2, maxSed, 255, 0), 255, 0, 255);
        }
        else //Menos del 50%
        {
			visualSed.color = new Color32(255, (byte)MapValues(ControlTarget.currentSed, 0, maxSed / 2, 0, 255), 0, 255);
        }
    }

    //Funcion que mapea las coordenadas (divide en porciones iguales lo que aumenta/disminuye la barra)
    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    //Funcion que inicia las corrutinas cruzadas que hacen disminuir la barra
    private void DescensoSed()
    {
        StartCoroutine(DS1());
    }

    //Corrutina 1
    private IEnumerator DS1()
    {
        yield return new WaitForSeconds(1.0f);

        if (CurrentSed != 0 && ComportamientoPatron.leon_en_escena)
            CurrentSed -= 1;

        StartCoroutine(DS2());
    }

    //Corrutina 2
    private IEnumerator DS2()
    {
        yield return new WaitForSeconds(1.0f);

		if (CurrentSed != 0 && ComportamientoPatron.leon_en_escena)
            CurrentSed -= 1;

        StartCoroutine(DS1());
    }
}
