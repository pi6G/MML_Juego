using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coins : MonoBehaviour
{
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreObject = GameObject.FindGameObjectWithTag("Score");
        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TMP_Text>();
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Coins: " + ScoreManager.Instance.GetScore().ToString();
    }
}
