using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject plantSelectionUI;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
    }

    public void StartGame() 
    {
        plantSelectionUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnGameOver ()
    {
        gameOverText.SetActive(true);
    }
}
