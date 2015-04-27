using UnityEngine;
using System.Collections;

public class characterMove : MonoBehaviour {

	public string UpDown;
	public string LeftRight;
	public string Jump;
	public string ThrowWeapon;

	public CharacterController cc;
	public Vector3 movement;
	public float speed;
	public float jumpDistance;
	public GameObject weapon;
	public hayheadStats stats;
	public bool damaged;

	public AudioClip[] sfx;
	public Animator anim;

	// Use this for initialization
	void Start(){
		cc = GetComponent<CharacterController>();
		movement = Vector3.zero;
		anim = GetComponent<Animator>();
		stats = GetComponent<hayheadStats>();
	}
	
	// Update is called once per frame
	void Update(){
		//Animations
		PlayAnimations();

		//Movement
		if(!damaged){
			Movement();
		}

		//Weapon Throw
		if(!damaged){
			if(Input.GetButtonDown(ThrowWeapon)){
				UseWeapon();
			}
		}
	}

	void PlayAnimations(){
		if(!damaged){
			if(Input.GetAxisRaw(LeftRight) > 0){
				transform.localScale = new Vector3(1,1,1);
			}else if(Input.GetAxisRaw(LeftRight) < 0){
				transform.localScale = new Vector3(-1,1,1);
			}

			if(cc.isGrounded){
				anim.Play("Idle");
			}else{
				if(cc.velocity.y < 0){
					anim.Play("Fall");
				}
			}
		}
	}

	void Movement(){
		movement.x = Input.GetAxisRaw(LeftRight)*speed;
		
		if(cc.isGrounded){
			movement.y = -0.0001f;
			if(Input.GetButtonDown(Jump)){
				AudioSource.PlayClipAtPoint(sfx[0],transform.position);
				movement.y = jumpDistance;
			}
		}else{
			movement.y += Physics.gravity.y;
		}
		
		cc.Move(movement*Time.deltaTime);
	}

	void UseWeapon(){
		if(stats.ammo > 0){
			stats.AdjustAmmo(-1);
			Instantiate(weapon,transform.position,weapon.transform.rotation);
		}
	}

	public IEnumerator beingDamaged(){
		damaged = true;
		Physics.IgnoreLayerCollision(8,9,true);
		anim.Play("Damage");
		AudioSource.PlayClipAtPoint(sfx[1],transform.position);
		yield return new WaitForSeconds(1);
		Physics.IgnoreLayerCollision(8,9,false);
		damaged = false;
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.layer == 9 && !damaged){
			stats.AdjustHealth(-col.GetComponent<enemyHealth>().damageDealt);
		}
	}
}