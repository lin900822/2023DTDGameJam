using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private characterMovement[] players = null;

    [SerializeField] private GameObject[] winnerPanel = null;

    [SerializeField] private Image[] hps = null;

    private bool isGameOver = false;
    private bool currentGameOver = false;
    private bool lastGameOver = false;
    
    private void Update()
    {
        switch (GetWinner())
        {
            case 0:
                winnerPanel[0].SetActive(true);

                currentGameOver = true;
                break;
            case 1:
                winnerPanel[1].SetActive(true);
                
                currentGameOver = true;
                break;
            case 2:
                winnerPanel[2].SetActive(true);
                
                currentGameOver = true;
                break;
            case 3:
                winnerPanel[3].SetActive(true);

                currentGameOver = true;
                break;
            default:
                
                break;
        }

        for (var i = 0; i < hps.Length; i++)
        {
            var hp = hps[i];
            var player = players[i];

            hp.fillAmount = ((float)player.Hp / 10);
        }

        if (lastGameOver != currentGameOver)
        {
            Invoke(nameof(SetGameOver), 3f);
        }

        if (isGameOver)
        {
            GameOver();
        }
        
        lastGameOver = currentGameOver;
    }

    private int GetWinner()
    {
        int alivePlayerCount = 0;
        
        foreach (var player in players)
        {
            if (player.Hp > 0)
            {
                alivePlayerCount++;
            }
        }

        if (alivePlayerCount <= 1)
        {
            foreach (var player in players)
            {
                if (player.Hp > 0)
                {
                    return player.PlayerID;
                }
            }
        }

        return -1;
    }

    private void SetGameOver()
    {
        isGameOver = true;
    }
    
    private void GameOver()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("New GamePlay");
        }
    }
}
