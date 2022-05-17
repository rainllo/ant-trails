using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
	// Function to detect if a queen ant has collided with a wall
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PrimeAnt")) // Detect if the queen ant collides with the wall...
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the game over scene
		}
	}
}
