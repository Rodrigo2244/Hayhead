using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hayheadStats : MonoBehaviour {

	public int health;
	public int maxHealth;

	public int ammo;
	public int maxAmmo;

	public int score;

	Text healthDisplay;
	Text ammoDisplay;
	Text scoreDisplay;

	// Use this for initialization
	void Start () {
		maxHealth = 10;
		health = maxHealth;

		maxAmmo = 10;
		ammo = maxAmmo;

		score = 0;

		healthDisplay = GameObject.Find("Health").GetComponent<Text>();
		ammoDisplay = GameObject.Find("Ammo").GetComponent<Text>();
		scoreDisplay = GameObject.Find("Score").GetComponent<Text>();
		AdjustHealth(0);
		AdjustScore(0);
	}
	
	// Update is called once per frame
	void Update () {
		if(health>maxHealth){
			health = maxHealth;
		}
	}

	public void AdjustHealth(int adjustment){

		if(adjustment < 0 && GetComponent<characterMove>().damaged == false){
			health += adjustment;
			StartCoroutine(GetComponent<characterMove>().beingDamaged());
		} else {
			health += adjustment;
		}

		healthDisplay.text = "Health: ";
		for(int i = 0; i < health; i++){
			healthDisplay.text += "|";
		}
	}

	public void AdjustAmmo(int amount){
		ammo += amount;
		ammoDisplay.text = "Ammo: "+ammo;
	}

	public void AdjustScore(int amount){
		score += amount;

		scoreDisplay.text = "Score: "+score;
	}
}