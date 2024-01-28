using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Coins : MonoBehaviour
{
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private TMP_Text scoreFinal;
    private TMP_Text scoreText;
    [SerializeField] private GameObject bufon;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TMP_Text>();
            UpdateScore();
        }

        bufon.transform.position = ScoreManager.Instance.position;

        if (ValidateFinal())
        {
            StartCoroutine(ShowFinalPanel());
        }
        
    }

    private bool ValidateFinal()
    {
        foreach (int castle in ScoreManager.Instance.castles)
        {
            if (castle != 0)
            {
                return false;
            }
        }
        return true;
    }

    private void UpdateScore()
    {
        scoreText.text = "Coins: " + ScoreManager.Instance.GetScore().ToString();
    }

    private IEnumerator ShowFinalPanel()
    {
        finalPanel.SetActive(true);
        scoreFinal.text = ScoreManager.Instance.GetScore().ToString();
        yield return new WaitForSeconds(4);
        ScoreManager.Instance.Reset();
        SceneManager.LoadScene("MainMenu");

    }
}
