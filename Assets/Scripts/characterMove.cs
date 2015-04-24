using UnityEngine;
using System.Collections;

public class characterMove : MonoBehaviour {

	public string UpDown;
	public string LeftRight;
	public string Jump;
	public string ThrowCorn;

	public CharacterController cc;
	public Vector3 movement;
	public float speed;
	public float jumpDistance;

	// Use this for initialization
	void Start(){
		cc = GetComponent<CharacterController>();
		movement = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update(){
		Debug.Log(cc.isGrounded);

		//Animations
		PlayAnimations();

		//Movement
		Movement();
	}

	void PlayAnimations(){
		if(Input.GetAxisRaw(LeftRight) > 0){
			transform.localScale = new Vector3(1,1,1);
		}else if(Input.GetAxisRaw(LeftRight) < 0){
			transform.localScale = new Vector3(-1,1,1);
		}
	}

	void Movement(){
		movement.x = Input.GetAxisRaw(LeftRight)*speed;
		
		if(cc.isGrounded){
			movement.y = -0.0001f;
			if(Input.GetButtonDown(Jump)){
				movement.y = jumpDistance;
			}
		}else{
			movement.y += Physics.gravity.y;
		}
		
		cc.Move(movement*Time.deltaTime);
	}
}
