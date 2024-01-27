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

    //private void Start()
    //{
    //    cameraSystem = GetComponent<CameraSystem>();
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
}
