using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

	public int health;
	public AudioClip sfx;
	Animator anim;
	public int damageDealt;
	bool beingDamaged;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		beingDamaged = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			GameObject.Find("Hayhead").GetComponent<hayheadStats>().AdjustScore(100);
			Destroy(gameObject);
		}
	}

	public void Damage(int damage){
		if(!beingDamaged){
			beingDamaged = true;
			anim.Play("Damage");
			AudioSource.PlayClipAtPoint(sfx,transform.position);
			health -= damage;
			StartCoroutine(Recover());
		}
	}

	IEnumerator Recover(){
		yield return new WaitForSeconds(1);
		beingDamaged = false;
	}
}