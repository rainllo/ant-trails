using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRecord : MonoBehaviour
{
    // Clear the previous record to start fresh
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll(); // Deletes all player prefs
    }
}
