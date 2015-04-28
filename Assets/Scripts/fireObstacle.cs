using UnityEngine;
using System.Collections;

public class fireObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.layer == 8){
			col.GetComponent<hayheadStats>().AdjustHealth(-2);
		}
	}
}
