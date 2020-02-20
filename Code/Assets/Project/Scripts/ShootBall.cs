using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{

	public GameObject Ball;
	public GameObject ballInHand;
	public static int power = 20;

	private void Start()
	{

	}

	void Update()
	{
		//if some key is pressed, the "fire" function is called
		if (Input.GetKeyDown("k"))
		{

			if (ballInHand.activeSelf == true)
			{
				ballInHand.SetActive(false);
				Fire();
			}
		}
	}

	void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		var ball = (GameObject)Instantiate(
			Ball,
			transform.position,
			transform.rotation
		);

		print(ball);


		// Add velocity to the bullet
		ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * power;



		// Debug log
		print("Shot");
	}
}

