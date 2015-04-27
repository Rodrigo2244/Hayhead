using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	void Play(){
		Application.LoadLevel("Main");
	}

	void Quit(){
		Application.Quit();
	}
}
