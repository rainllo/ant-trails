using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweet : MonoBehaviour
{
	public AudioClip collectSound; // The sound that plays when a dessert is collected

	// Function to detect if the queen ant has collected a dessert
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PrimeAnt")) // If queen ant collides with dessert...
		{
			other.GetComponent<AntQueenMovement>().AddWorker(); // Add a worker ant
			AudioSource.PlayClipAtPoint(collectSound, transform.position); // Play a collection sound
			Destroy(gameObject); // Remove the dessert object
		}
	}
}
