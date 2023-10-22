using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void OnGameOver ()
    {
        gameOverText.SetActive(true);
    }
}
