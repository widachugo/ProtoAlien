using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelVictory;

    public GameObject panelDeathPlayer;

    public Object levelScene;

    public int trap;
    public Text trapNumber;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void DeathPlayer()
    {
        panelDeathPlayer.SetActive(true);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        panelVictory.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(levelScene.name);
    }

    private void Update()
    {
        int trapCalculed = trap / 2;
        trapNumber.text = trapCalculed.ToString();
    }
}
