using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private CharacterController controller;
    private Vector3 sidewaysDirection = Vector3.zero;
	private Vector3 movementOffset = Vector3.zero;
	public float gravity = -9.81f;
	public float gravityScale = 1;
	public float jumpHeight = 4;
	public float speed = 100f;
	public float zPosition;
	private float velocity;
	public GameOver gameOver;

	void Start()
    {	
        	controller = GetComponent <CharacterController>();
    }

	void MovePlayer()
	{
		controller.Move(new Vector3(sidewaysDirection.x, velocity, sidewaysDirection.z) * Time.deltaTime);
	}

	void Update()
    {
		// Force one constant z position
		if (transform.position.z != zPosition)
		{
			movementOffset.z = (zPosition - transform.position.z) * 0.5f;
			controller.Move(movementOffset);
		}
		
		// Jump
		if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			velocity = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
		}
		velocity += gravity * gravityScale * Time.deltaTime;


		// Sideways move calculation
		if (controller.isGrounded)
        {
			sidewaysDirection = Input.GetAxis("Horizontal") * speed * transform.right;
		}
		
		MovePlayer();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

		}
		if (other.gameObject.CompareTag("Obstacle"))
		{
			gameOver.Show();
		}

	}

	
}
