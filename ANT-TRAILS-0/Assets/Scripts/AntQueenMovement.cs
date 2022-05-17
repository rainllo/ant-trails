using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro

public class AntQueenMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Base speed of the ants
    public float rotateSpeed = 180.0f; // Speed ants rotate left or right
    public float keySpeed; // Speed when boosting

    public List<GameObject> workerObjects = new List<GameObject>(); // List of worker ants
    public GameObject workerPrefab; // The worker ant prefab

    public TextMeshProUGUI score; // Variable to update the current score
    public int scoreCount = 0; // The score count

    public TextMeshProUGUI record; // Variable to update the record score
    public int recordCount = 0; // The record count


    // Start is called before the first frame update
    void Start()
    {
        recordCount = PlayerPrefs.GetInt("highScore"); // Load the record high score
        workerObjects.Add(gameObject); // Add a worker
    }

    // Update is called once per frame
    void Update()
    {
        keySpeed = moveSpeed; // Make the boost speed the base speed

        if (Input.GetKey("up")) // If press up arrow key...
        {
            keySpeed *= 2; // double the speed
        }

        transform.position += transform.forward * keySpeed * Time.deltaTime; // Move forward by increasing the position by key speed and delta 

        float rotateDirection = Input.GetAxis("Horizontal"); // Rotation value based on the arrow key pressed, -1 is left, 1 is right and 0 is neither
        transform.Rotate(Vector3.up * rotateDirection * rotateSpeed * Time.deltaTime); // Rotate based on vector3 up/y-axis, multiply by rotation speed and delta time

        score.text = scoreCount.ToString(); // Update the current and record scores
        record.text = recordCount.ToString();
    }

    // Function to add a worker to the ant trail
    public void AddWorker()
    {
        Vector3 newWorkerPosition = workerObjects[workerObjects.Count - 1].transform.position; // The new worker ant should spawn at the lcoation of the last worker ant.
        moveSpeed += 0.2f; // Slightly increase the base speed.
        rotateSpeed += 5.0f; // Increase the rotation speed.
        workerObjects.Add(GameObject.Instantiate(workerPrefab, newWorkerPosition, Quaternion.identity) as GameObject); // Instantiate a worker ant, at the new position and align itself to the parent
        scoreCount++; // Increment the sore
        if (scoreCount > recordCount) // If the current score is greater than the previous record...
        {
            PlayerPrefs.SetInt("highScore", scoreCount); // update the previous record
        }
    }
}
