using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Back : MonoBehaviour {
    public Text textbuttonexit;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void cambiarBack()
    {
        textbuttonexit.text = "Back";
    }

    void cambiarExit()
    {
        textbuttonexit.text = "Exit";
    }
}
