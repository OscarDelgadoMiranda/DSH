using UnityEngine;
using System.Collections;

public class RestartTeclado : MonoBehaviour {

    public void Restart()
    {
		SceneManager.tiempo = 0;
		SceneManager.score = 0;
        Application.LoadLevel("Pantalla1");
    }
}
