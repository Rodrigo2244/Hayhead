using UnityEngine;
using System.Collections;

public class crowEnemy : MonoBehaviour {
	
	CharacterController cc;
	bool isDiving;
	Transform hayhead;
	int direction;
	bool ascending;
	public float speed;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
		isDiving = false;
		ascending = false;
		hayhead = GameObject.Find("Hayhead").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(transform.position,new Vector3(transform.localScale.x,1,0)*-10,Color.red);

		if(Vector3.Distance(transform.position,hayhead.position) < 10 && hayhead.position.y < transform.position.y){
			isDiving = true;
			transform.parent.GetComponent<Animator>().enabled = false;
		}

		if(isDiving){
			if(!ascending){
				transform.localScale = new Vector3(-direction,1,1);
				speed = 12;
				cc.Move(new Vector3(direction*Mathf.Abs(hayhead.position.x-transform.position.x),-Mathf.Abs(transform.position.y-hayhead.position.y),0).normalized*Time.deltaTime*speed);
			} else {
				speed = 6;
				cc.Move(new Vector3(direction*Mathf.Abs(hayhead.position.x-transform.position.x),Mathf.Abs(transform.position.y-hayhead.position.y),0).normalized*Time.deltaTime*speed);
			}
		} else {
			getDirection();
		}

		if(cc.isGrounded){
			ascending = true;
			StartCoroutine(Ascend ());
		}
	}

	void getDirection(){
		if(transform.position.x > hayhead.position.x){
			direction = -1;
		} else if (transform.position.x < hayhead.position.x){
			direction = 1;
		}
	}

	IEnumerator Ascend(){
		yield return new WaitForSeconds(1.5f);
		getDirection();
		ascending = false;
	}
}