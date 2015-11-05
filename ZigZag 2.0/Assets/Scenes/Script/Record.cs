using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Record : MonoBehaviour {

    public Text record;
    // Use this for initialization
    void Start()
    {
        record.text = "El record esta en : " + PlayerPrefs.GetInt("Guardado") + " puntos";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
