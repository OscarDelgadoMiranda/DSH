using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuardarPuntuacion : MonoBehaviour
{
    public Text puntuacion;
    public Text texto;
	public Text record;
	int actuales;
    void Start()
    {
        Grabar();
    }


    public void Grabar()
    {
        if(PlayerPrefs.HasKey("puntosactuales"))
		{
			actuales = SceneManager.score * 10 - SceneManager.tiempo;
			actuales = actuales + PlayerPrefs.GetInt("puntosactuales");
		}
		else
		{
			actuales = SceneManager.score * 10 - SceneManager.tiempo;
		}
        if (actuales > PlayerPrefs.GetInt("Guardado"))
        {
            PlayerPrefs.SetInt("Guardado",actuales);
            PlayerPrefs.Save();
            texto.text = "Enhorabuena, record superado";
        }

        else
            texto.text = "Record no superado";
    }

    void Update()
    {
			record.text = "El record esta en : " + PlayerPrefs.GetInt ("Guardado", actuales) + "puntos";
			puntuacion.text = "Tu puntuacion: "+actuales+" puntos";
    }

}
