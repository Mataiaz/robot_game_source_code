using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject victoryscreen;
    public GameObject gameOver;
    void Update() {
        // Get all GameObjects with the tag "boxxx"
        GameObject[] boxxxObjects = GameObject.FindGameObjectsWithTag("boxxx");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(boxxxObjects.Length == 0) {
            victoryscreen.SetActive(true);
            Time.timeScale = 0f;
        }
            
        if(players.Length == 0) {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
