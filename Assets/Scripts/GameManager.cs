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

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
    }

<<<<<<< Updated upstream
    public void StartGame() 
    {
        plantSelectionUI.SetActive(false);
        Time.timeScale = 1;
=======
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
        
        int seconds = ((int)gameSeconds % 60);
        int minutes = ((int)gameSeconds / 60);
        timerText.text = "Time: " + minutes.ToString() + ":" + (seconds < 10 ? "0" :"") + seconds.ToString();
    }

    public void Win()
    {
        onWin.Invoke();

        Time.timeScale = 0.0f;
>>>>>>> Stashed changes
    }

    public void OnGameOver ()
    {
        gameOverText.SetActive(true);
    }
}
