using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpasePlatformer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManader : MonoBehaviour
{
    public static GameManader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        Player.OnDiedPlayer += PlayerOnDiedPlayer;
    }

    private void OnDisable()
    {
        Player.OnDiedPlayer -= PlayerOnDiedPlayer;
    }

    private void PlayerOnDiedPlayer()
    {
        UIController.Instance.ShowPopup();
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
