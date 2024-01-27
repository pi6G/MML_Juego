using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    private Joke joke;
    [SerializeField] private TMP_Text textUI;
    [SerializeField] private CameraSystem cameraSystem;
    [SerializeField] private Score score;

    public float scoreQuantity;

    private Category category;

    //private void Start()
    //{
    //    score = GetComponent<Score>();
    //}

    public void UpdateJoke(Joke joke)
    {
        this.joke = joke;
        textUI.text = joke.GetJokeContent();
    }

    public void IncreaseCamera()
    {
        cameraSystem.Zoom();
    }

    public void ScoreUpdate()
    {
        score.AddScore(scoreQuantity);
    }
}
