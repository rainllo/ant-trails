using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetSpawner : MonoBehaviour
{
    public float xSize = 8.0f; // size of x-axis from -8 to 8
    public float zSize = 8.0f; // size of z-axis from -8 to 8

    public GameObject currentSweet; // The dessert object
    public Vector3 currentSweetPosition; // The position where the dessert should spawn

    public List<GameObject> sweetPrefab = new List<GameObject>(); // List of dessert objects
    private int randomNum; // Variable for a random number

    // Function spawns a new dessert object
    void AddNewSweet()
    {
        RandomPosition(); // Call the random position function
        randomNum = Random.Range(0, sweetPrefab.Count); // Pick a random dessert from the 4 choices (index 0 to 3)
        currentSweet = GameObject.Instantiate(sweetPrefab[randomNum], currentSweetPosition, Quaternion.identity) as GameObject; // Instantiate a random dessert in a random coordinate

    }

    // Function to pick a random x and z coordinate, y-axis is constant
    void RandomPosition()
    {
        currentSweetPosition = new Vector3(Random.Range(-xSize, xSize), 1f, Random.Range(-zSize, zSize));

    }

    // Update is called once per frame
    void Update()
    {
        if (!currentSweet) // If there is no dessert on the field...
        {
            AddNewSweet(); // Add a new dessert
        }
    }
}
