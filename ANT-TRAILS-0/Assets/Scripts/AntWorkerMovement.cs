using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntWorkerMovement : MonoBehaviour
{
    public float moveSpeed; // The base speed
    public float keySpeed; // The boost speed
     
    public GameObject workerTrail; // The worker ant object in the trail
    public Vector3 workerTrailPosition; // The position of the worker ant in the trail

    public AntQueenMovement mainAnt; // The queen ant is the main ant
    public int numberAnts; // The number of ants in the trail

    // Start is called before the first frame update
    void Start()
    {
        mainAnt = GameObject.FindWithTag("PrimeAnt").GetComponent<AntQueenMovement>(); // Find the ant with the tag PrimeAnt, this is the queen ant
        workerTrail = mainAnt.workerObjects[mainAnt.workerObjects.Count - 2]; // Add the worker in the trail 2 positions behind
        numberAnts = mainAnt.workerObjects.IndexOf(gameObject); // Keep track of the indexes of the worker ants
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = mainAnt.keySpeed; // The speed of the worker ants is the same as the queen ant
        workerTrailPosition = workerTrail.transform.position; // Update the position of where the new worker ant should be
        transform.LookAt(workerTrailPosition); // Rotate the position of the new worker ant to the previous worker ant
        transform.position = Vector3.Lerp(transform.position, workerTrailPosition, Time.deltaTime * moveSpeed); // Interpolate the position between the previous ant and new ant
    }

    // Function to detect if the queen ant has crashed with a worker ant in the trail
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PrimeAnt") && numberAnts > 2) // If queen ant collides with the trail, and is long enough...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load game over scene
        }
    }
}
