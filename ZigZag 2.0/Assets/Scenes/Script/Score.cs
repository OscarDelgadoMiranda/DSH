using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text score;
	// Use this for initialization
	void Start () {
        score.text = SceneManager.score.ToString() + " x";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
