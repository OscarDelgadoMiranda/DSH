using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nombres : MonoBehaviour {
    public Text n1;
    public Text n2;
    public Text n3;
    public Text n4;

	// Use this for initialization
	void Start () 
    {
        n1.text = "";
        n2.text = "";
        n3.text = "";
        n4.text = "";
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public void Creditos()
    {
        StartCoroutine(DoIT());
    }

    private IEnumerator DoIT()
    {
        n1.text = "Óscar Delgado Miranda";
        n2.text = "Ildefonso de la Cruz Romero";
        n3.text = "Miguel Ángel Pérez García";
        n4.text = "Juan Francisco García Pereira";

        yield return new WaitForSeconds(10.0f);

        n1.text = "";
        n2.text = "";
        n3.text = "";
        n4.text = "";
    }
}
