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
    [SerializeField] private KingManager king;

    public int mood = 0;

    private Category category;

    //private void Start()
    //{
    //    score = GetComponent<Score>();
    //}

    public void UpdateJoke(Joke joke)
    {
        this.joke = joke;
        textUI.text = joke.JokeContent;
    }

    public void IncreaseCamera()
    {
        cameraSystem.Zoom();
    }

    public void MoodUpdate()
    {
        king.ModifyMood(joke.Category);
    }
}
