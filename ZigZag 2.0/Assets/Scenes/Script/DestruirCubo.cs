using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestruirCubo : MonoBehaviour
{
    public Text Score;
    public static int Destruidos;

	void Start()
	{
		Destruidos = SceneManager.score;
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cubo")
        {
            Destruidos++;
            Score.text = Destruidos + " x";
            Destroy(col.gameObject);
			SceneManager.score = Destruidos;
        }

        if (col.gameObject.name == "Fin")
        {
            int actuales = SceneManager.score * 10 - SceneManager.tiempo;
            Score.text = Destruidos + " x";
            PlayerPrefs.SetInt("puntosactuales", actuales);
            PlayerPrefs.Save();
            Application.LoadLevel("Pantalla2");
        }
        if (col.gameObject.name == "Fin2")
            Application.LoadLevel("Final");
    }
}
