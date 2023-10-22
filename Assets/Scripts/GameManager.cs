using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject plantSelectionUI;

    public static GameManager instance;
    public float gameSeconds;

    public TMPro.TextMeshProUGUI timerText;
    public UnityEvent onWin;
    bool a;

    private void Awake()
    {
        instance = this;
        //Time.timeScale = 0;
    }

    public void StartGame()
    {
        a = true;
        Time.timeScale = 1.0f;
        plantSelectionUI.SetActive(false);
    }
    private void Update()
    {
        if ((int)gameSeconds <= 0)
        {
            Win();
        }
        else
        {
            gameSeconds -= Time.deltaTime;
        }
        if(a)
        Time.timeScale = 1.0f;


        int seconds = ((int)gameSeconds % 60);
        int minutes = ((int)gameSeconds / 60);
        timerText.text = "Time: " + minutes.ToString() + ":" + (seconds < 10 ? "0" :"") + seconds.ToString();
    }

    public void Win()
    {
        onWin.Invoke();

        Time.timeScale = 0.0f;
    }

    public void OnGameOver ()
    {
        gameOverText.SetActive(true);
    }
}
