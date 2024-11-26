using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{
    public void Update()
    {
        AllFruitsCollected();
    }


    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan frutas. Ganaste!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}

