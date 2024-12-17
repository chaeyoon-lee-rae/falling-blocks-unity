using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverObject;
    public TextMeshProUGUI secondsSurvived;
    bool gameOver;

    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnGameOver()
    {
        gameoverObject.SetActive(true);
        secondsSurvived.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
