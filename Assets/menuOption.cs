using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuOption : MonoBehaviour
{
    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
