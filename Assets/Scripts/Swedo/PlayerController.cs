using UnityEngine;
using System.Collections;

/* Test movement script, Jan.16.
 * Working on a simple movement script for my test scene as an example for everyone's assignments.
 * Feel free to reference this script for coding style, comment style, etc.
 * This is NOT complete code - the input lags significantly and I'm not sure how to fix it, but I just wanted to provide a
 * basis for us to work on this.
*/

public class PlayerController : MonoBehaviour 
{
	// Store a float for our movement speed, make it public so we can edit it in the Inspector.
	public float movementSpeed = .1f;
	// Store our current position, so we can modify our transform.
	Vector3 currentPosition;
	// Set up an object for a reference to the environment (which is a simple plane with the tag "Walkable Environment")
	// so that we may reference its collider.
	GameObject walkableEnvironment;

	void Start() 
	{
		// Set up our reference to our position. In C# in Unity, you CANNOT modify this value directly.
		// You must store it in a temporary variable and set it to that temporary variable.
		currentPosition = transform.position;
		// Set up our reference to the environment. We search for the object that has the tag "Walkable Environment."
		walkableEnvironment = GameObject.FindGameObjectWithTag("Walkable Environment");
	}

	// Update function handles our movement, and nothing else, at the moment.
	void Update() 
	{
		HandleMovement();
	}

	// Movement Handling function, which handles movement in both the X and Y dimensions.
	void HandleMovement()
	{
		/* 
		 * Input in Unity uses Buttons and Axes. Getting the Horizontal Axis will return a value between -1 and 1, depending
		 * on which button is currently pressed. Pressing the A or Left Arrow keys will return a value of -1,
		 * D or Right Arrow returns a 1. Up or W returns 1 in the Vertical Axis, and Down Arrow or S returns -1.
		 * I specifically use "if" statements here (and not else if) because the actions of horizontal and vertical 
		 * movement are NOT mutually exclusive. You should be able to do both simultaneously.
		*/

		if(Input.GetAxis("Horizontal") > 0)
		{
			// We then check to see if our collider will move outside the bounds of the walkable environment.
			// If it would, we do not do the movement.
			// This could be refactored to be a separate function.
			if(walkableEnvironment.collider.bounds.max.x > this.collider.bounds.max.x + movementSpeed)
			{
				// If we CAN move, we change the current position,
				currentPosition.x += movementSpeed;
				// And then change the transform's position by setting it to our temp variable.
				transform.position = currentPosition;
			}
		}

		if(Input.GetAxis("Horizontal") < 0)
		{
			if(walkableEnvironment.collider.bounds.min.x < this.collider.bounds.min.x - movementSpeed)
			{
				currentPosition.x -= movementSpeed;
				transform.position = currentPosition;
			}
		}

		if(Input.GetAxis("Vertical") > 0)
		{
			if(walkableEnvironment.collider.bounds.max.y > this.collider.bounds.max.y + movementSpeed)
			{
				currentPosition.y += movementSpeed;
				transform.position = currentPosition;
			}
		}

		if(Input.GetAxis("Vertical") < 0)
		{
			if(walkableEnvironment.collider.bounds.min.y < this.collider.bounds.min.y - movementSpeed)
			{
				currentPosition.y -= movementSpeed;
				transform.position = currentPosition;
			}
		}
	}
}
