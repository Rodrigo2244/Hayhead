using UnityEngine;
using System.Collections;

public class pitchforkWeapon : MonoBehaviour {

	int direction;
	public float speed;

	// Use this for initialization
	void Start () {
		direction = (int)GameObject.Find("Hayhead").transform.localScale.x;
		transform.localScale = new Vector3(GameObject.Find("Hayhead").transform.localScale.x,1,1);
		
		StartCoroutine(Eliminate());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(direction,0,0)*Time.deltaTime*speed);
	}

	IEnumerator Eliminate(){
		yield return new WaitForSeconds(5);
		Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.layer == 9){
			col.GetComponent<enemyHealth>().Damage(2);
		}
	}
}