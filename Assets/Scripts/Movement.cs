using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Rigidbody playerRb;

	bool canJump;


	[SerializeField]
	float jumpSpeed;

	[SerializeField]
	float movementSpeed;

	void Start () {
		canJump = false;

	}

	void FixedUpdate()
	{
		#if (UNITY_EDITOR)
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * movementSpeed * Time.fixedDeltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * movementSpeed * Time.fixedDeltaTime;
		}
		#endif

	
	}

	void Update()
	{

		if (canJump) {

			if(Input.GetKeyDown(KeyCode.Space))
			{

				Jump();
			}

		}

	}

	/*void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		playerRb.AddForce (movement * movementSpeed);

	}*/

	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "platform") {

			canJump = true;


		}

	}

	void Jump()
	{
		playerRb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
		canJump = false;
	}
}
