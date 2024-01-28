using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public ScoreManager scoreManager;

    public void BackToMenu()
    {

        ScoreManager.Instance.Reset();
        SceneManager.LoadScene("MainMenu");
    }
}
