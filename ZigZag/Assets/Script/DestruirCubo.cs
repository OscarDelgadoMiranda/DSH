using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestruirCubo : MonoBehaviour
{
	public Text Score;
	public static int Destruidos=0;
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Cubo")
		{
			Destroy(col.gameObject);
			Destruidos++;
			Score.text = Destruidos + " x";
		}

		if (col.gameObject.name == "Fin")
			Application.LoadLevel (1);
		if (col.gameObject.name == "Fin2")
			Application.LoadLevel (2);
	}
}