using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelWin;

    public GameObject gameOverPannal;
    public GameObject levelWinPannal;

    public static int CurrentLevelIndex;
    public static int noOfPassingRings;


    public TextMeshProUGUI currentlevelText;
    public TextMeshProUGUI nextLeveltext;

    public Slider ProgressBar;

    public void Awake()
    {
        CurrentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        noOfPassingRings = 0;
        gameOver = false;
        levelWin = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPannal.SetActive(true);
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        currentlevelText.text = CurrentLevelIndex.ToString();
        nextLeveltext.text= (CurrentLevelIndex+1).ToString();

        int proggress = noOfPassingRings * 100 / FindObjectOfType<HelixManager>().noOfRings;
        ProgressBar.value = proggress;

        if (levelWin)
        {
            levelWinPannal.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", CurrentLevelIndex + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
