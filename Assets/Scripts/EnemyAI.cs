using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	bool right; //right collider to trigger movement <-
	bool left; // left collider to triggr movement ->

	[SerializeField]
	float movementSpeed;


	void Start () {
		left = false;
		right = true;
	}
	

	void Update () {
		if (left) {
			transform.position += Vector3.right * movementSpeed * Time.fixedDeltaTime;
		

		}
		if (right) {
			transform.position += Vector3.left * movementSpeed * Time.fixedDeltaTime;

		}
	}


	public void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "leftcollider") {

			left = true;
			right = false;

		}


		if (col.gameObject.tag == "rightcollider") {
			right = true;
			left = false;

		}


	}
}
